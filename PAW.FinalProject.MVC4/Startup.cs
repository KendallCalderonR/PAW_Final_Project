using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PAW.FinalProject.MVC4.Startup))]
namespace PAW.FinalProject.MVC4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
