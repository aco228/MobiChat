using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobiChat.Web.Startup))]
namespace MobiChat.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
