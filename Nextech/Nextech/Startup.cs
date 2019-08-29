using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nextech.Startup))]
namespace Nextech
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
