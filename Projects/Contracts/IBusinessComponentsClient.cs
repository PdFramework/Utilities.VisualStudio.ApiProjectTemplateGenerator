using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Contracts
{
  public interface IBusinessComponentsClient
  {
    Task<IEnumerable<BusinessComponent>> GetAllBusinessComponents();
    Task<BusinessComponent> GetBusinessComponent(int id);
    Task<BusinessComponent> CreateBusinessComponent(BusinessComponent businessComponent);
    Task<BusinessComponent> UpdateBusinessComponent(BusinessComponent businessComponent);
    Task DeleteBusinessComponent(int id);
  }
}
