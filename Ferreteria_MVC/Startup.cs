using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ferreteria_MVC.Startup))]
namespace Ferreteria_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
