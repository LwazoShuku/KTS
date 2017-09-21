using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KTS.Startup))]
namespace KTS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
