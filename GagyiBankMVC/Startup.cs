using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GagyiBankMVC.Startup))]
namespace GagyiBankMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
