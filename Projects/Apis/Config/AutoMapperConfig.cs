using AutoMapper;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Contracts;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.DataAccess;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Apis
{
  public class AutoMapperConfig
  {
    public static IMapper Mapper { get; protected set; }

    public static void Configure()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<BusinessComponentDto, BusinessComponent>();
        cfg.CreateMap<BusinessComponent, BusinessComponentDto>();
      });

      Mapper = config.CreateMapper();
    }
  }
}
