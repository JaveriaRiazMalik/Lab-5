using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab5.Startup))]
namespace Lab5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
