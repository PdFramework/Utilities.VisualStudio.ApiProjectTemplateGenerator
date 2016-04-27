using System.Data.Entity;
using System.Threading.Tasks;
using PeinearyDevelopment.Framework.ApiBases.Data.Entity;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.DataAccess
{
  public class BusinessComponentsDal : DbContextBase<BusinessComponentDto>, IBusinessComponentsDal
  {
    public BusinessComponentsDal(DbContext businessComponentsDbContext) : base(businessComponentsDbContext)
    {
    }
    public async Task<BusinessComponentDto> Update(BusinessComponentDto businessComponentDto)
    {
      var storedBusinessComponentDto = await Read(businessComponentDto.Id);
      storedBusinessComponentDto.StartDateTimeOffset = businessComponentDto.StartDateTimeOffset;
      storedBusinessComponentDto.StopDateTimeOffset = businessComponentDto.StopDateTimeOffset;
      await DbContext.SaveChangesAsync();
      return storedBusinessComponentDto;
    }
  }
}
