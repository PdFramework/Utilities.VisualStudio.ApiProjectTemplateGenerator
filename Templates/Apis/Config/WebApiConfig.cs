using System.Web.Http;

namespace $customnamespace$.Apis.Config
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}
