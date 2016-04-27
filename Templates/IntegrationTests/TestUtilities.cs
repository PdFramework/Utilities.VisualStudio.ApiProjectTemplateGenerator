using $customnamespace$.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace $customnamespace$.IntegrationTests
{
  public static class TestUtilities
  {
    public static void AreSame($specificconceptsingularized$ expected$specificconceptsingularized$, $specificconceptsingularized$ actual$specificconceptsingularized$)
    {
      Assert.AreEqual(expected$specificconceptsingularized$.Id, actual$specificconceptsingularized$.Id);
      Assert.AreEqual(expected$specificconceptsingularized$.StartDateTimeOffset, actual$specificconceptsingularized$.StartDateTimeOffset);
      Assert.AreEqual(expected$specificconceptsingularized$.StopDateTimeOffset, actual$specificconceptsingularized$.StopDateTimeOffset);
    }
  }
}
