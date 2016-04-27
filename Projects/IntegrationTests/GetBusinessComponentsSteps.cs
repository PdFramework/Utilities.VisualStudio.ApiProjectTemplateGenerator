using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.ApiClients;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Contracts;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.IntegrationTests
{
  [Binding]
  public class GetBusinessComponentsSteps
  {
    private IEnumerable<BusinessComponent> _businessComponentsFromGet;
    private int? _specifiedBusinessComponentId;
    private BusinessComponent _businessComponentSpecifiedByIdFromGet;
    private HttpRequestException _exception;

    private IBusinessComponentsClient BusinessComponentsClient { get; }

    public GetBusinessComponentsSteps()
    {
      BusinessComponentsClient = new BusinessComponentsClient();
    }

    [Given(@"the following business components")]
    public void GivenIHaveTheFollowingBusinessComponents(Table table)
    {
      var businessComponents = table.CreateSet<BusinessComponent>();

      foreach (var businessComponent in businessComponents)
      {
        var createdBusinessComponent = BusinessComponentsClient.CreateBusinessComponent(businessComponent).Result;
        BusinessComponentsTestsContext.CreatedTestBusinessComponents.Add(createdBusinessComponent);
      }
    }

    [When(@"GET is invoked on the business components api")]
    public void WhenGETIsInvokedOnTheBusinessComponentsApi()
    {
      _businessComponentsFromGet = BusinessComponentsClient.GetAllBusinessComponents().Result;
    }

    [Then(@"the business components should be returned")]
    public void ThenTheBusinessComponentsShouldBeReturned()
    {
      foreach (var businessComponentFromGet in _businessComponentsFromGet)
      {
        TestUtilities.AreSame(BusinessComponentsTestsContext.CreatedTestBusinessComponents.First(s => s.Id == businessComponentFromGet.Id), businessComponentFromGet);
      }
    }

    [When(@"GET is invoked on the business components api with a specified id")]
    public void WhenGETIsInvokedOnTheBusinessComponentsApiWithASpecifiedId()
    {
      try
      {
        _businessComponentSpecifiedByIdFromGet = BusinessComponentsClient.GetBusinessComponent(_specifiedBusinessComponentId ?? _businessComponentsFromGet.First().Id).Result;
      }
      catch (HttpRequestException ex)
      {
        _exception = ex;
      }
    }

    [Then(@"the business component should be returned")]
    public void ThenTheBusinessComponentShouldBeReturned()
    {
      TestUtilities.AreSame(BusinessComponentsTestsContext.CreatedTestBusinessComponents.First(s => s.Id == _specifiedBusinessComponentId), _businessComponentSpecifiedByIdFromGet);
    }

    [Given(@"the following invalid business component id (.*)")]
    public void GivenIHaveTheFollowingBusinessComponents(int invalidId)
    {
      _specifiedBusinessComponentId = invalidId;
    }

    [Then(@"the exception message should contain the status code (.*)")]
    public void ThenTheExceptionMessageShouldContainTheStatusCode(int statusCode)
    {
      Assert.IsTrue(_exception.Message.StartsWith(statusCode.ToString()));
    }
  }
}
