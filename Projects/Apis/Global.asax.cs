using System.Web;
using System.Web.Http;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Apis
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
