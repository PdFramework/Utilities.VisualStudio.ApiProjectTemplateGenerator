using System.Data.Entity;
using System.Web.Http;
using Microsoft.Practices.Unity;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.DataAccess;
using Unity.WebApi;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Apis
{
  public static class UnityConfig
  {
    public static void RegisterComponents()
    {
      var container = new UnityContainer();

      container.RegisterType<DbContext, BusinessComponentsDbContext>();

      container.RegisterType<IBusinessComponentsDal, BusinessComponentsDal>();

      GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    }
  }
}