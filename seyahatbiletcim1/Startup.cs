using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(seyahatbiletcim1.Startup))]
namespace seyahatbiletcim1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
