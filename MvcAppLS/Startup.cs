using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAppLS.Startup))]
namespace MvcAppLS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
