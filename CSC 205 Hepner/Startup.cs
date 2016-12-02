using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSC_205_Hepner.Startup))]
namespace CSC_205_Hepner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
