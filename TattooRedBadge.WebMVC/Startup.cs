using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TattooRedBadge.WebMVC.Startup))]
namespace TattooRedBadge.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
