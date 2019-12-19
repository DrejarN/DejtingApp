using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DejtingApp.Startup))]
namespace DejtingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
