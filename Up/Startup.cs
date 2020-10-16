using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Up.Startup))]
namespace Up
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
