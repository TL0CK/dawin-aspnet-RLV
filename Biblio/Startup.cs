using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Biblio.Startup))]
namespace Biblio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
