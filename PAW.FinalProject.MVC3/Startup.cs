using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PAW.FinalProject.MVC3.Startup))]
namespace PAW.FinalProject.MVC3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
