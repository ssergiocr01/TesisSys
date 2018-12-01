using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesisSys.Startup))]
namespace TesisSys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
