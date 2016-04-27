using System.Linq;
using System.Threading.Tasks;
using $customnamespace$.DataAccess;
using PeinearyDevelopment.Framework.ApiBases.Data.Entity.UnitTesting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace $customnamespace$.UnitTests.DataAccess
{
  [TestClass]
  public class $specificconcept$DalTests : DbContextTestsBase<$specificconceptsingularized$Dto>
  {
    private I$specificconcept$Dal $specificconcept$Dal { get; set; }

    private static readonly IQueryable<$specificconceptsingularized$Dto> $specificconcept$DtoTestDataSet = new[]
    {
      new $specificconceptsingularized$Dto
      {
        Id = TestData.FirstValid$specificconceptsingularized$Id,
        StartDateTimeOffset = TestData.FirstStartDateTimeOffset,
        StopDateTimeOffset = TestData.FirstStopDateTimeOffset
      },
      new $specificconceptsingularized$Dto
      {
        Id = TestData.SecondValid$specificconceptsingularized$Id,
        StartDateTimeOffset = TestData.SecondStartDateTimeOffset,
        StopDateTimeOffset = TestData.SecondStopDateTimeOffset
      }
    }.AsQueryable();

    public $specificconcept$DalTests() : base($specificconcept$DtoTestDataSet)
    {
    }

    [TestInitialize]
    public void Initialize()
    {
      $specificconcept$Dal = new $specificconcept$Dal(MockDbContext.Object);
    }

    #region Update Tests
    [TestMethod]
    [TestCategory("$specificconcept$Dal Update")]
    public async Task Given_A$specificconceptsingularized$_When_UpdateIsInvoked_Then_SaveChangesAsyncMethodShouldBeInvokedOnlyOnce()
    {
      await $specificconcept$Dal.Update(new $specificconceptsingularized$Dto { Id = TestData.FirstValid$specificconceptsingularized$Id });

      MockDbContext.Verify(m => m.SaveChangesAsync(), Times.Once());
    }

    [TestMethod]
    [TestCategory("$specificconcept$Dal Update")]
    public async Task Given_A$specificconceptsingularized$_When_UpdateIsInvoked_Then_ExpectedPropertiesGetUpdatedValues()
    {
      var $pascalspecificconceptsingularized$ToUpdate = new $specificconceptsingularized$Dto
      {
        Id = TestData.FirstValid$specificconceptsingularized$Id,
        StartDateTimeOffset = TestData.SecondStartDateTimeOffset,
        StopDateTimeOffset = TestData.SecondStopDateTimeOffset
      };

      var $pascalspecificconceptsingularized$Returned = await $specificconcept$Dal.Update($pascalspecificconceptsingularized$ToUpdate);

      Assert.AreEqual($pascalspecificconceptsingularized$ToUpdate.StartDateTimeOffset, $pascalspecificconceptsingularized$Returned.StartDateTimeOffset);
      Assert.AreEqual($pascalspecificconceptsingularized$ToUpdate.StopDateTimeOffset, $pascalspecificconceptsingularized$Returned.StopDateTimeOffset);
    }

    [TestMethod]
    [TestCategory("$specificconcept$Dal Update")]
    public async Task Given_A$specificconceptsingularized$_When_UpdateIsInvoked_Then_ExpectedPropertiesShouldNotGetUpdatedValues()
    {
      var $pascalspecificconceptsingularized$ToUpdate = new $specificconceptsingularized$Dto
      {
        Id = TestData.FirstValid$specificconceptsingularized$Id,
        StartDateTimeOffset = TestData.SecondStartDateTimeOffset,
        StopDateTimeOffset = TestData.SecondStopDateTimeOffset
      };

      var $pascalspecificconceptsingularized$Returned = await $specificconcept$Dal.Update($pascalspecificconceptsingularized$ToUpdate);

      Assert.AreEqual($pascalspecificconceptsingularized$Returned.Id, TestData.FirstValid$specificconceptsingularized$Id);
    }
    #endregion
  }
}
