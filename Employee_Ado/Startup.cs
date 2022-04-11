using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Employee_Ado.Startup))]
namespace Employee_Ado
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
