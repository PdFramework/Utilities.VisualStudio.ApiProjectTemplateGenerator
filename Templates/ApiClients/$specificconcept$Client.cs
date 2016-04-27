using System.Collections.Generic;
using System.Threading.Tasks;
using $customnamespace$.Contracts;
using PeinearyDevelopment.Framework.ApiBases.ApiClients;

namespace $customnamespace$.ApiClients
{
    public class $specificconcept$Client : I$specificconcept$Client
    {
      public async Task<IEnumerable<$specificconceptsingularized$>> GetAll$specificconcept$()
      {
        return await ApiInvoker.GetAll<$specificconceptsingularized$>(Constants.$specificconcept$EndpointKey, Constants.Base$specificconcept$RoutePrefix);
      }

      public async Task<$specificconceptsingularized$> Get$specificconceptsingularized$(int id)
      {
        return await ApiInvoker.Get<$specificconceptsingularized$, int>(Constants.$specificconcept$EndpointKey, Constants.Base$specificconcept$RoutePrefix, id);
      }

      public async Task<$specificconceptsingularized$> Create$specificconceptsingularized$($specificconceptsingularized$ $pascalspecificconceptsingularized$)
      {
        return await ApiInvoker.Create(Constants.$specificconcept$EndpointKey, Constants.Base$specificconcept$RoutePrefix, $pascalspecificconceptsingularized$);
      }

      public async Task<$specificconceptsingularized$> Update$specificconceptsingularized$($specificconceptsingularized$ $pascalspecificconceptsingularized$)
      {
        return await ApiInvoker.Update(Constants.$specificconcept$EndpointKey, Constants.Base$specificconcept$RoutePrefix, $pascalspecificconceptsingularized$);
      }

      public async Task Delete$specificconceptsingularized$(int id)
      {
        await ApiInvoker.Delete(Constants.$specificconcept$EndpointKey, Constants.Base$specificconcept$RoutePrefix, id);
      }
    }
}
