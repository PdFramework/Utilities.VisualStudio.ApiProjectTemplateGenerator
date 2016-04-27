using System;

namespace $customnamespace$.UnitTests
{
  public static class TestData
  {
    static TestData()
    {
      FirstStartDateTimeOffset = DateTimeOffset.UtcNow.AddDays(-10);
      SecondStartDateTimeOffset = DateTimeOffset.UtcNow.AddDays(-15);
      FirstStopDateTimeOffset = DateTimeOffset.UtcNow.AddDays(10);
      SecondStopDateTimeOffset = DateTimeOffset.UtcNow.AddDays(15);
    }

    #region DateTimeOffset 'const' values
    public static DateTimeOffset FirstStartDateTimeOffset { get; set; }
    public static DateTimeOffset SecondStartDateTimeOffset { get; set; }
    public static DateTimeOffset? FirstStopDateTimeOffset { get; set; }
    public static DateTimeOffset? SecondStopDateTimeOffset { get; set; }
    #endregion

    #region $specificconcept$Data
    public const int Invalid$specificconceptsingularized$Id = -1;
    public const int FirstValid$specificconceptsingularized$Id = 1;
    public const int SecondValid$specificconceptsingularized$Id = 2;
    #endregion
  }
}
