using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(anderbakk.HomeAutomation.WebApi.Startup))]

namespace anderbakk.HomeAutomation.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            
            WebApiConfig.Register(new HttpConfiguration());
        }
    }
}
