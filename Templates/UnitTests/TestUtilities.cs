using $customnamespace$.Contracts;
using $customnamespace$.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace $customnamespace$.UnitTests
{
  public static class TestUtilities
  {
    public static void AreSame($specificconceptsingularized$Dto expected$specificconceptsingularized$, $specificconceptsingularized$Dto actual$specificconceptsingularized$)
    {
      Assert.AreEqual(expected$specificconceptsingularized$.Id, actual$specificconceptsingularized$.Id);
      Assert.AreEqual(expected$specificconceptsingularized$.StartDateTimeOffset, actual$specificconceptsingularized$.StartDateTimeOffset);
      Assert.AreEqual(expected$specificconceptsingularized$.StopDateTimeOffset, actual$specificconceptsingularized$.StopDateTimeOffset);
    }

    public static void AreSame($specificconceptsingularized$ expected$specificconceptsingularized$, $specificconceptsingularized$ actual$specificconceptsingularized$)
    {
      Assert.AreEqual(expected$specificconceptsingularized$.Id, actual$specificconceptsingularized$.Id);
      Assert.AreEqual(expected$specificconceptsingularized$.StartDateTimeOffset, actual$specificconceptsingularized$.StartDateTimeOffset);
      Assert.AreEqual(expected$specificconceptsingularized$.StopDateTimeOffset, actual$specificconceptsingularized$.StopDateTimeOffset);
    }
  }
}
