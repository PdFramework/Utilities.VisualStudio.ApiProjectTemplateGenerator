using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using PeinearyDevelopment.Framework.ApiBases.Web.Http;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Contracts;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.DataAccess;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Apis.Controllers
{
  [RoutePrefix(Constants.BaseBusinessComponentsRoutePrefix)]
  public class BusinessComponentsController : ApiControllerBase<BusinessComponent, BusinessComponentDto>
  {
    public IBusinessComponentsDal BusinessComponentsDal { get; }

    public BusinessComponentsController(IBusinessComponentsDal businessComponentsDal) : base(businessComponentsDal, AutoMapperConfig.Mapper)
    {
      BusinessComponentsDal = businessComponentsDal;
    }

    [Route("")]
    public override async Task<IHttpActionResult> Get()
    {
      return await base.Get();
    }

    [Route("{id:int}")]
    public override async Task<IHttpActionResult> Get(int id)
    {
      return await base.Get(id);
    }

    [Route("")]
    public override async Task<IHttpActionResult> Post(BusinessComponent businessComponent)
    {
      var validationErrors = await ValidateContractsObject(businessComponent);
      if (validationErrors.Length > 0) return BadRequest(validationErrors.ToString());

      var createdBusinessComponentDto = await Dal.Create(AutoMapperConfig.Mapper.Map<BusinessComponentDto>(businessComponent));
      var createdBusinessComponent = AutoMapperConfig.Mapper.Map<BusinessComponent>(createdBusinessComponentDto);

      return Ok(createdBusinessComponent);
    }

    [Route("")]
    public override async Task<IHttpActionResult> Put(BusinessComponent businessComponent)
    {
      return await base.Put(businessComponent);
    }

    [Route("{id:int}")]
    public override async Task<IHttpActionResult> Delete(int id)
    {
      try
      {
        var businessComponent = await Dal.Read(id);
        businessComponent.StopDateTimeOffset = DateTimeOffset.UtcNow;
        await Dal.Update(businessComponent);

        return Ok();
      }
      catch (KeyNotFoundException)
      {
        return NotFound();
      }
    }

    [Route("{id:int}/force")]
    public async Task<IHttpActionResult> ForceDelete(int id)
    {
      return await base.Delete(id);
    }

    public override Task<StringBuilder> ValidateContractsObject(BusinessComponent businessComponent)
    {
      var stringBuilder = new StringBuilder().ValidateDateRangeBase(businessComponent);

      return Task.Factory.StartNew(() => stringBuilder);
    }
  }
}
