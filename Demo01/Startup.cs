using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo01.Startup))]
namespace Demo01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
