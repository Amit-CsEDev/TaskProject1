using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskProject.Web.Startup))]
namespace TaskProject.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
