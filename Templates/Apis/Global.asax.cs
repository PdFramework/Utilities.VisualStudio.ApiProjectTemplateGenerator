using System.Web;
using System.Web.Http;
using $customnamespace$.Apis.Config;

namespace $customnamespace$.Apis
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
          AutoMapperConfig.Configure();
          UnityConfig.RegisterComponents();
          GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
