using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CritProject.Startup))]
namespace CritProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
