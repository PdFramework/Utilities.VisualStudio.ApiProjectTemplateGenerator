using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using $customnamespace$.Apis.Config;
using $customnamespace$.Contracts;
using $customnamespace$.DataAccess;
using PeinearyDevelopment.Framework.ApiBases.Web.Http;

namespace $customnamespace$.Apis.Controllers
{
  [RoutePrefix(Constants.Base$specificconcept$RoutePrefix)]
  public class $specificconcept$Controller : ApiControllerBase<$specificconceptsingularized$, $specificconceptsingularized$Dto>
  {
    public I$specificconcept$Dal $specificconcept$Dal { get; }

    public $specificconcept$Controller(I$specificconcept$Dal $pascalspecificconcept$Dal) : base($pascalspecificconcept$Dal, AutoMapperConfig.Mapper)
    {
      $specificconcept$Dal = $pascalspecificconcept$Dal;
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
    public override async Task<IHttpActionResult> Post($specificconceptsingularized$ $pascalspecificconceptsingularized$)
    {
      var validationErrors = await ValidateContractsObject($pascalspecificconceptsingularized$);
      if (validationErrors.Length > 0) return BadRequest(validationErrors.ToString());

      var created$specificconceptsingularized$Dto = await Dal.Create(AutoMapperConfig.Mapper.Map<$specificconceptsingularized$Dto>($pascalspecificconceptsingularized$));
      var created$specificconceptsingularized$ = AutoMapperConfig.Mapper.Map<$specificconceptsingularized$>(created$specificconceptsingularized$Dto);

      return Ok(created$specificconceptsingularized$);
    }

    [Route("")]
    public override async Task<IHttpActionResult> Put($specificconceptsingularized$ $pascalspecificconceptsingularized$)
    {
      return await base.Put($pascalspecificconceptsingularized$);
    }

    [Route("{id:int}")]
    public override async Task<IHttpActionResult> Delete(int id)
    {
      try
      {
        var $pascalspecificconceptsingularized$ = await Dal.Read(id);
        $pascalspecificconceptsingularized$.StopDateTimeOffset = DateTimeOffset.UtcNow;
        await Dal.Update($pascalspecificconceptsingularized$);

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

    public override Task<StringBuilder> ValidateContractsObject($specificconceptsingularized$ $pascalspecificconceptsingularized$)
    {
      var stringBuilder = new StringBuilder().ValidateDateRangeBase($pascalspecificconceptsingularized$);

      return Task.Factory.StartNew(() => stringBuilder);
    }
  }
}
