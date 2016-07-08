using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Challenger.Startup))]
namespace Challenger
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
