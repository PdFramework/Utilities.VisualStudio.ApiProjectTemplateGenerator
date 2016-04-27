using System.Data.Entity;
using System.Threading.Tasks;
using PeinearyDevelopment.Framework.ApiBases.Data.Entity;

namespace $customnamespace$.DataAccess
{
  public class $specificconcept$Dal : DbContextBase<$specificconceptsingularized$Dto>, I$specificconcept$Dal
  {
    public $specificconcept$Dal(DbContext $pascalspecificconcept$DbContext) : base($pascalspecificconcept$DbContext)
    {
    }
    public async Task<$specificconceptsingularized$Dto> Update($specificconceptsingularized$Dto $pascalspecificconceptsingularized$Dto)
    {
      var stored$specificconceptsingularized$Dto = await Read($pascalspecificconceptsingularized$Dto.Id);
      stored$specificconceptsingularized$Dto.StartDateTimeOffset = $pascalspecificconceptsingularized$Dto.StartDateTimeOffset;
      stored$specificconceptsingularized$Dto.StopDateTimeOffset = $pascalspecificconceptsingularized$Dto.StopDateTimeOffset;
      await DbContext.SaveChangesAsync();
      return stored$specificconceptsingularized$Dto;
    }
  }
}
