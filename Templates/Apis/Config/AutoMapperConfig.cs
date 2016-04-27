using AutoMapper;
using $customnamespace$.Contracts;
using $customnamespace$.DataAccess;

namespace $customnamespace$.Apis.Config
{
  public class AutoMapperConfig
  {
    public static IMapper Mapper { get; protected set; }

    public static void Configure()
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<$specificconceptsingularized$Dto, $specificconceptsingularized$>();
        cfg.CreateMap<$specificconceptsingularized$, $specificconceptsingularized$Dto>();
      });

      Mapper = config.CreateMapper();
    }
  }
}
