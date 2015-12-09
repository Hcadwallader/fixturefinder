using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FixtureFinder.Startup))]
namespace FixtureFinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
