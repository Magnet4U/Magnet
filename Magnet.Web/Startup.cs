using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Magnet.Web.Startup))]
namespace Magnet.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
