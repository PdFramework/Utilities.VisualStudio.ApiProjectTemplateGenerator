using System.Collections.Generic;
using $customnamespace$.Contracts;
using TechTalk.SpecFlow;

namespace $customnamespace$.IntegrationTests
{
  public class $specificconcept$TestsContext
  {
    private const string CreatedTest$specificconcept$Key = "CreatedTest$specificconcept$Key";

    public static IList<$specificconceptsingularized$> CreatedTest$specificconcept$
    {
      get { return GetScenarioContextParameter<IList<$specificconceptsingularized$>>(CreatedTest$specificconcept$Key); }
      set { SetScenarioContextParameter(value, CreatedTest$specificconcept$Key); }
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
