using PeinearyDevelopment.Framework.ApiBases.DataAccess;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.DataAccess
{
  public interface IBusinessComponentsDal : IDbContextBase<BusinessComponentDto>
  {
  }
}
