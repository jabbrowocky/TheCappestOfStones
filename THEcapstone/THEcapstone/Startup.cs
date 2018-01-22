using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(THEcapstone.Startup))]
namespace THEcapstone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
