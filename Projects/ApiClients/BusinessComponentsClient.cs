using System.Collections.Generic;
using System.Threading.Tasks;
using PeinearyDevelopment.Framework.ApiBases.ApiClient;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Contracts;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.ApiClients
{
    public class BusinessComponentsClient : IBusinessComponentsClient
    {
      public async Task<IEnumerable<BusinessComponent>> GetAllBusinessComponents()
      {
        return await ApiInvoker.GetAll<BusinessComponent>(Constants.BusinessComponentsEndpointKey, Constants.BaseBusinessComponentsRoutePrefix);
      }

      public async Task<BusinessComponent> GetBusinessComponent(int id)
      {
        return await ApiInvoker.Get<BusinessComponent, int>(Constants.BusinessComponentsEndpointKey, Constants.BaseBusinessComponentsRoutePrefix, id);
      }

      public async Task<BusinessComponent> CreateBusinessComponent(BusinessComponent businessComponent)
      {
        return await ApiInvoker.Create(Constants.BusinessComponentsEndpointKey, Constants.BaseBusinessComponentsRoutePrefix, businessComponent);
      }

      public async Task<BusinessComponent> UpdateBusinessComponent(BusinessComponent businessComponent)
      {
        return await ApiInvoker.Update(Constants.BusinessComponentsEndpointKey, Constants.BaseBusinessComponentsRoutePrefix, businessComponent);
      }

      public async Task DeleteBusinessComponent(int id)
      {
        await ApiInvoker.Delete(Constants.BusinessComponentsEndpointKey, Constants.BaseBusinessComponentsRoutePrefix, id);
      }
    }
}
