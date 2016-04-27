using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PeinearyDevelopment.Framework.Endpoints.ApiClient;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.ApiClients;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Contracts;
using TechTalk.SpecFlow;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.IntegrationTests
{
  [Binding]
  public sealed class BusinessComponentsTestsHooks
  {
    private IBusinessComponentsClient BusinessComponentsClient { get; set; }

    [BeforeScenario("GetBusinessComponents")]
    public void BeforeScenario()
    {
      BusinessComponentsClient = new BusinessComponentsClient();
      BusinessComponentsTestsContext.CreatedTestBusinessComponents = new List<BusinessComponent>();
    }

    [AfterScenario("GetBusinessComponents")]
    public void CleanupData()
    {
      Task.WaitAll(BusinessComponentsTestsContext.CreatedTestBusinessComponents.Select(createdTestBusinessComponent => DeleteBusinessComponent(createdTestBusinessComponent.Id)).ToArray());
    }

    private static async Task DeleteBusinessComponent(int id)
    {
      var uri = Path.Combine(new[] {new EndpointResolverClient().ResolveEndpoint(Constants.BusinessComponentsEndpointKey), Constants.BaseBusinessComponentsRoutePrefix, id.ToString(), "force"});

      using (var client = new HttpClient())
      {
        using (var response = await client.DeleteAsync(uri))
        {
          if (!response.IsSuccessStatusCode) throw new Exception(response.Content.ToString());
        }
      }
    }
  }
}
