using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

/*
Copyright 2015 NIC Federal

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
namespace NICBizDev.RIDB
{
    /// <summary>
    /// A delegate type that returns a single result page from the RIDB API.
    /// </summary>
    /// <typeparam name="T">The type of RIDB object being returned from the search.</typeparam>
    /// <param name="searchParams">Search parameters that should be used in conducting the search.</param>
    /// <returns>A single page of RIDB searh results.</returns>
    public delegate RIDBList<T> GetPageDelegate<T>(RIDBSearchParameters searchParams);

    /// <summary>
    /// The RIDB client allows .NET applications to interact with the RIDB JSON services to get recreation information.  You should not be calling methods
    /// from this object.  Instead you should access the appropriate entity module property (e.g. Organization, RecArea, Facility, etc.) and use entity specific methods
    /// to return data from RIDB.
    /// </summary>
    public class RIDBClient
    {
        /// <summary>
        /// The RIDB Developer API key.  This can also be set with the "RIDB.ApiKey" appSetting.
        /// </summary>
        public string ApiKey { get; private set; }

        /// <summary>
        /// The base url to use when constructing RIDB API urls.  This can also be set with the "RIDB.BaseUrl" appSetting.
        /// </summary>
        public string BaseUrl { get; private set; }

        /// <summary>
        /// When turned on, debug will output the URL and JSON response from the RIDB API to the debug stream.  Can also be set with the "RIDB.DebugOn" appSetting.  Defaults to false.
        /// </summary>
        public bool DebugOn { get; set; }

        /// <summary>
        /// The client module used to access RIDB information about organizations.
        /// </summary>
        public RIDBClientModOrg Organization { get; private set; }
        /// <summary>
        /// The client module used to access RIDB information about recreation areas.
        /// </summary>
        public RIDBClientModRecArea RecArea { get; private set; }
        /// <summary>
        /// The client module used to access RIDB information about organizations.
        /// </summary>
        public RIDBClientModFacility Facility { get; private set; }
        /// <summary>
        /// The client module used to access RIDB information about campsites.
        /// </summary>
        public RIDBClientModCampsite Campsite { get; private set; }
        /// <summary>
        /// The client module used to access RIDB information about permit entrances.
        /// </summary>
        public RIDBClientModPermitEntrance PermitEntrance { get; private set; }
        /// <summary>
        /// The client module used to access RIDB information about tours.
        /// </summary>
        public RIDBClientModTour Tour { get; private set; }
        /// <summary>
        /// The client module used to access RIDB information about recreation activities.
        /// </summary>
        public RIDBClientModActivity Activity { get; private set; }
        /// <summary>
        /// The client module used to access RIDB information about events.
        /// </summary>
        public RIDBClientModEvent Event { get; private set; }
        /// <summary>
        /// The client module used to access RIDB information about media.
        /// </summary>
        public RIDBClientModMedia Media { get; private set; }
        /// <summary>
        /// The client module used to access RIDB information about reacreation links.
        /// </summary>
        public RIDBClientModLink Link { get; private set; }

        /// <summary>
        /// Constructs a new RIDB client object using RIDB settings stored in the AppSettings.  The following AppSettings are
        /// used by the client.
        /// <ul>
        /// <li>RIDB.BaseUrl - The base URL for RIDB</li>
        /// <li>RIDB.ApiKey - The RIDB API key</li>
        /// <li>RIDB.DebugOn - If true, extra information is sent to the debug stream.</li>
        /// </ul>
        /// </summary>
        public RIDBClient()
        {
            DebugOn = false;

            var configUrl = ConfigurationManager.AppSettings["RIDB.BaseUrl"];
            var configKey = ConfigurationManager.AppSettings["RIDB.ApiKey"];
            var configDebugOn = ConfigurationManager.AppSettings["RIDB.DebugOn"];
            if (configUrl == null || configKey == null)
                throw new ConfigurationErrorsException("Missing required RIDB configuration in AppSettings");

            ApiKey = configKey;
            BaseUrl = configUrl;
            if (configDebugOn != null && configDebugOn.ToUpper().Equals("TRUE")) DebugOn = true;

            InitModules();
        }

        /// <summary>
        /// Constructs a new RIDB client object using the configuration information provided as parameters.
        /// </summary>
        /// <param name="baseUrl">The base URL for RIDB (e.g. "https://ridb.recreation.gov/api/v1")</param>
        /// <param name="apiKey">The API key string assigned to a developer</param>
        public RIDBClient(string baseUrl, string apiKey)
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
            DebugOn = false;

            InitModules();
        }

        /// <summary>
        /// Creates the client modules that will be used to interact with RIDB
        /// </summary>
        private void InitModules()
        {
            Organization = new RIDBClientModOrg(this);
            RecArea = new RIDBClientModRecArea(this);
            Facility = new RIDBClientModFacility(this);
            Campsite = new RIDBClientModCampsite(this);
            PermitEntrance = new RIDBClientModPermitEntrance(this);
            Tour = new RIDBClientModTour(this);
            Activity = new RIDBClientModActivity(this);
            Event = new RIDBClientModEvent(this);
            Media = new RIDBClientModMedia(this);
            Link = new RIDBClientModLink(this);
        }

        /// <summary>
        /// Sends a request URL to RIDB and parses the response into an object.  This should not typically be called directly.  Instead call
        /// the methods on each of the client modules which will in turn call this method.
        /// </summary>
        /// <typeparam name="T">The class of object that corresponds to the response back from RIDB.</typeparam>
        /// <param name="requestUrl">The well formed URL of the RIDB API function.</param>
        /// <returns>An object or array of objects corresponding to the data sent back from the RIDB API.</returns>
        public T MakeRequest<T>(string requestUrl)
        {
            if (DebugOn) Debug.WriteLine(requestUrl);
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                request.Headers["apikey"] = ApiKey;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                    var json = ReadResponseStream(response);
                    if (DebugOn) Debug.WriteLine(json);
                    return JsonConvert.DeserializeObject<T>(json);                          
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }

        }

        /// <summary>
        /// Format a search URL using the configured base url, a path format template, and the search parameters.  This method should not
        /// typically be called directly.  Instead call the methods on each of the client modules which will in turn use this method to create
        /// the appropriate URL.
        /// </summary>
        /// <param name="pathFormat">The format string for the RIDB API function being called.</param>
        /// <param name="pathParams">The parameters which should be applied to the format string.</param>
        /// <param name="searchParams">The RIDB search parameters object.</param>
        /// <returns>A well formed RIDB API URL</returns>
        public string FormatSearchUrl(string pathFormat, string[] pathParams, RIDBSearchParameters searchParams)
        {
            var qp = new Dictionary<string, string>();
            if (searchParams != null)
            {
                if (searchParams.Query != null && searchParams.Query.Length > 0) qp["query"] = searchParams.Query;
                if (searchParams.Limit.HasValue) qp["limit"] = searchParams.Limit.Value.ToString();
                if (searchParams.Offset.HasValue) qp["offset"] = searchParams.Offset.Value.ToString();
                if (searchParams.Latitude.HasValue) qp["latitude"] = searchParams.Latitude.Value.ToString();
                if (searchParams.Longitude.HasValue) qp["longitude"] = searchParams.Longitude.Value.ToString();
                if (searchParams.Radius.HasValue) qp["radius"] = searchParams.Radius.Value.ToString();
                if (searchParams.StateList != null && searchParams.StateList.Length > 0) qp["state"] = searchParams.StateList;
                if (searchParams.ActivityList != null && searchParams.ActivityList.Length > 0) qp["activity"] = searchParams.ActivityList;
                if (searchParams.LastUpdated.HasValue) qp["lastupdated"] = searchParams.LastUpdated.Value.ToString("yyyy-MM-dd");
            }
            return FormatUrl(pathFormat, pathParams, qp);

        }

        /// <summary>
        /// Format a RIDB URL using a path template, parameters for that template, and a dictionary of keys/values for the query string portion.  This method should not
        /// typically be called directly.  Instead call the methods on each of the client modules which will in turn use this method to create
        /// the appropriate URL.
        /// </summary>
        /// <param name="pathFormat">The format string for the RIDB API function being called.</param>
        /// <param name="pathParms">The parameters which should be applied to the format string.</param>
        /// <param name="queryParms">A dictionary containing key/values that will be included in the query string.</param>
        /// <returns>A well formed RIDB URL.</returns>
        public string FormatUrl(string pathFormat, string[] pathParms, Dictionary<string,string> queryParms)
        {
            var ret = new StringBuilder();
            ret.Append(BaseUrl);
            ret.Append(String.Format(pathFormat, pathParms));
            if (queryParms != null && queryParms.Count > 0)
            {
                ret.Append('?');
                bool first = true;
                foreach (var key in queryParms.Keys)
                {
                    if (!first)
                        ret.Append('&');
                    else
                        first = false;
                    ret.Append(Uri.EscapeDataString(key));
                    ret.Append('=');
                    ret.Append(Uri.EscapeDataString(queryParms[key]));
                }
            }
            return ret.ToString();
        }

        /// <summary>
        /// Internal method to read the entire response into a string.
        /// </summary>
        /// <param name="response">The web response object.</param>
        /// <returns>The response contents as a string.</returns>
        private string ReadResponseStream(HttpWebResponse response)
        {
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                var value = reader.ReadToEnd();
                return value;
            }
        }

        /// <summary>
        /// Returns all results from a call.  When searching RIDB, pages of results are generated.  This method
        /// will call a method repeatedly to aggregate all of the results from all pages of results.  This method should not
        /// typically be called directly.  Instead call the methods on each of the client modules which will in turn use this method if
        /// the module function requires retrieval of all results.
        /// </summary>
        /// <typeparam name="T">The type of RIDB object included in the results.</typeparam>
        /// <param name="searchParams">Any search parameters</param>
        /// <param name="pager">A delegate that is expected to return a single page of results.</param>
        /// <returns>An array of all of the results from all result pages.</returns>
        public T[] GetAll<T>(RIDBSearchParameters searchParams, GetPageDelegate<T> pager)
        {
            if (searchParams == null) searchParams = new RIDBSearchParameters();
            searchParams.Offset = 0;
            searchParams.Limit = 50;

            var results = new List<T>();
            bool atEnd = false;

            while (!atEnd)
            {
                var page = pager(searchParams);
                results.AddRange(page.Data);
                atEnd = (results.Count >= page.MetaData.Results.TotalCount) || (page.MetaData.Results.CurrentCount == 0);
                searchParams.Offset += page.MetaData.Results.CurrentCount;
            }

            return results.ToArray();
        }
       
    }

    /// <summary>
    /// A base class for the client modules which are specific to entities within RIDB.
    /// </summary>
    public class RIDBClientModule
    {
        /// <summary>
        /// A reference to the client which owns the module
        /// </summary>
        protected RIDBClient Client { get; set; }

        /// <summary>
        /// Disallow use of the default constructor.
        /// </summary>
        private RIDBClientModule() { ; }

        /// <summary>
        /// Construct a new module object.
        /// </summary>
        /// <param name="client">The client object that owns the client module.</param>
        public RIDBClientModule(RIDBClient client)
        {
            Client = client;
        }

    }
}
