using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobiChat.Management.Startup))]
namespace MobiChat.Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
