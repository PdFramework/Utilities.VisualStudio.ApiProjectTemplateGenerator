using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Contracts;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.DataAccess;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.UnitTests
{
  public static class TestUtilities
  {
    public static void AreSame(BusinessComponentDto expectedBusinessComponent, BusinessComponentDto actualBusinessComponent)
    {
      Assert.AreEqual(expectedBusinessComponent.Id, actualBusinessComponent.Id);
      Assert.AreEqual(expectedBusinessComponent.StartDateTimeOffset, actualBusinessComponent.StartDateTimeOffset);
      Assert.AreEqual(expectedBusinessComponent.StopDateTimeOffset, actualBusinessComponent.StopDateTimeOffset);
    }

    public static void AreSame(BusinessComponent expectedBusinessComponent, BusinessComponent actualBusinessComponent)
    {
      Assert.AreEqual(expectedBusinessComponent.Id, actualBusinessComponent.Id);
      Assert.AreEqual(expectedBusinessComponent.StartDateTimeOffset, actualBusinessComponent.StartDateTimeOffset);
      Assert.AreEqual(expectedBusinessComponent.StopDateTimeOffset, actualBusinessComponent.StopDateTimeOffset);
    }
  }
}
