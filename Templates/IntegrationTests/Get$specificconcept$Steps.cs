using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using $customnamespace$.ApiClients;
using $customnamespace$.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace $customnamespace$.IntegrationTests
{
  [Binding]
  public class Get$specificconcept$Steps
  {
    private IEnumerable<$specificconceptsingularized$> _$pascalspecificconcept$FromGet;
    private int? _specified$specificconceptsingularized$Id;
    private $specificconceptsingularized$ _$pascalspecificconceptsingularized$SpecifiedByIdFromGet;
    private HttpRequestException _exception;

    private I$specificconcept$Client $specificconcept$Client { get; }

    public Get$specificconcept$Steps()
    {
      $specificconcept$Client = new $specificconcept$Client();
    }

    [Given(@"the following $humanizedspecificconcept$")]
    public void GivenIHaveTheFollowing$specificconcept$(Table table)
    {
      var $pascalspecificconcept$ = table.CreateSet<$specificconceptsingularized$>();

      foreach (var $pascalspecificconceptsingularized$ in $pascalspecificconcept$)
      {
        var created$specificconceptsingularized$ = $specificconcept$Client.Create$specificconceptsingularized$($pascalspecificconceptsingularized$).Result;
        $specificconcept$TestsContext.CreatedTest$specificconcept$.Add(created$specificconceptsingularized$);
      }
    }

    [When(@"GET is invoked on the $humanizedspecificconcept$ api")]
    public void WhenGETIsInvokedOnThe$specificconcept$Api()
    {
      _$pascalspecificconcept$FromGet = $specificconcept$Client.GetAll$specificconcept$().Result;
    }

    [Then(@"the $humanizedspecificconcept$ should be returned")]
    public void ThenThe$specificconcept$ShouldBeReturned()
    {
      foreach (var $pascalspecificconceptsingularized$FromGet in _$pascalspecificconcept$FromGet)
      {
        TestUtilities.AreSame($specificconcept$TestsContext.CreatedTest$specificconcept$.First(s => s.Id == $pascalspecificconceptsingularized$FromGet.Id), $pascalspecificconceptsingularized$FromGet);
      }
    }

    [When(@"GET is invoked on the $humanizedspecificconcept$ api with a specified id")]
    public void WhenGETIsInvokedOnThe$specificconcept$ApiWithASpecifiedId()
    {
      try
      {
        _$pascalspecificconceptsingularized$SpecifiedByIdFromGet = $specificconcept$Client.Get$specificconceptsingularized$(_specified$specificconceptsingularized$Id ?? _$pascalspecificconcept$FromGet.First().Id).Result;
      }
      catch (HttpRequestException ex)
      {
        _exception = ex;
      }
    }

    [Then(@"the $humanizedspecificconceptsingularized$ should be returned")]
    public void ThenThe$specificconceptsingularized$ShouldBeReturned()
    {
      TestUtilities.AreSame($specificconcept$TestsContext.CreatedTest$specificconcept$.First(s => s.Id == _specified$specificconceptsingularized$Id), _$pascalspecificconceptsingularized$SpecifiedByIdFromGet);
    }

    [Given(@"the following invalid $humanizedspecificconceptsingularized$ id (.*)")]
    public void GivenIHaveTheFollowing$specificconcept$(int invalidId)
    {
      _specified$specificconceptsingularized$Id = invalidId;
    }

    [Then(@"the exception message should contain the status code (.*)")]
    public void ThenTheExceptionMessageShouldContainTheStatusCode(int statusCode)
    {
      Assert.IsTrue(_exception.Message.StartsWith(statusCode.ToString()));
    }
  }
}
