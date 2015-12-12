using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DripScript.Startup))]
namespace DripScript
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
