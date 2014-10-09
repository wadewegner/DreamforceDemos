using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo2.Startup))]
namespace Demo2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
