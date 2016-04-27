using System;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.UnitTests
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

    #region BusinessComponentsData
    public const int InvalidBusinessComponentId = -1;
    public const int FirstValidBusinessComponentId = 1;
    public const int SecondValidBusinessComponentId = 2;
    #endregion
  }
}
