using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IOT_Tree_MVC5.Startup))]
namespace IOT_Tree_MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
