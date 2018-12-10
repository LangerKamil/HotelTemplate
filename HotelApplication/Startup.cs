using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelApplication.Startup))]
namespace HotelApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
