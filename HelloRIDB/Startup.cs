using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloRIDB.Startup))]
namespace HelloRIDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
