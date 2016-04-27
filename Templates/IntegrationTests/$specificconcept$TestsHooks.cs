using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using $customnamespace$.ApiClients;
using $customnamespace$.Contracts;
using PeinearyDevelopment.Framework.Endpoints.ApiClient;
using TechTalk.SpecFlow;

namespace $customnamespace$.IntegrationTests
{
  [Binding]
  public sealed class $specificconcept$TestsHooks
  {
    private I$specificconcept$Client $specificconcept$Client { get; set; }

    [BeforeScenario("Get$specificconcept$")]
    public void BeforeScenario()
    {
      $specificconcept$Client = new $specificconcept$Client();
      $specificconcept$TestsContext.CreatedTest$specificconcept$ = new List<$specificconceptsingularized$>();
    }

    [AfterScenario("Get$specificconcept$")]
    public void CleanupData()
    {
      Task.WaitAll($specificconcept$TestsContext.CreatedTest$specificconcept$.Select(createdTest$specificconceptsingularized$ => Delete$specificconceptsingularized$(createdTest$specificconceptsingularized$.Id)).ToArray());
    }

    private static async Task Delete$specificconceptsingularized$(int id)
    {
      var uri = Path.Combine(new[] {new EndpointResolverClient().ResolveEndpoint(Constants.$specificconcept$EndpointKey), Constants.Base$specificconcept$RoutePrefix, id.ToString(), "force"});

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
