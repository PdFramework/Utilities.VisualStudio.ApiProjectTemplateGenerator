using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using $customnamespace$.DataAccess;
using Unity.WebApi;

namespace $customnamespace$.Apis.Config
{
  public static class UnityConfig
  {
    public static void RegisterComponents()
    {
      var container = new UnityContainer();

      container.RegisterType<DbContext, $specificconcept$DbContext>();

      container.RegisterType<I$specificconcept$Dal, $specificconcept$Dal>();

      GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }
  }
}