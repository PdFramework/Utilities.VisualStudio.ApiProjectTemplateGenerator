using System.Collections.Generic;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Contracts;
using TechTalk.SpecFlow;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.IntegrationTests
{
  public class BusinessComponentsTestsContext
  {
    private const string CreatedTestBusinessComponentsKey = "CreatedTestBusinessComponentsKey";

    public static IList<BusinessComponent> CreatedTestBusinessComponents
    {
      get { return GetScenarioContextParameter<IList<BusinessComponent>>(CreatedTestBusinessComponentsKey); }
      set { SetScenarioContextParameter(value, CreatedTestBusinessComponentsKey); }
    }

    private static T GetScenarioContextParameter<T>(string key)
    {
      return ScenarioContext.Current.ContainsKey(key) ? ScenarioContext.Current.Get<T>(key) : default(T);
    }

    private static void SetScenarioContextParameter<T>(T value, string key)
    {
      if (value == null)
        ScenarioContext.Current.Remove(key);
      else
        ScenarioContext.Current.Set(value, key);
    }
  }
}
