using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_201503025MVC_CRUD.Startup))]
namespace _201503025MVC_CRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
