using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PA_FAdocsys.Startup))]
namespace PA_FAdocsys
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
