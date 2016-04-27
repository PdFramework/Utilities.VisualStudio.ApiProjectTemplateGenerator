using System.Linq;
using System.Threading.Tasks;
using PeinearyDevelopment.Framework.ApiBases.Data.Entity.UnitTesting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.DataAccess;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.UnitTests.DataAccess
{
  [TestClass]
  public class BusinessComponentsDalTests : DbContextTestsBase<BusinessComponentDto>
  {
    private IBusinessComponentsDal BusinessComponentsDal { get; set; }

    private static readonly IQueryable<BusinessComponentDto> BusinessComponentsDtoTestDataSet = new[]
    {
      new BusinessComponentDto
      {
        Id = TestData.FirstValidBusinessComponentId,
        StartDateTimeOffset = TestData.FirstStartDateTimeOffset,
        StopDateTimeOffset = TestData.FirstStopDateTimeOffset
      },
      new BusinessComponentDto
      {
        Id = TestData.SecondValidBusinessComponentId,
        StartDateTimeOffset = TestData.SecondStartDateTimeOffset,
        StopDateTimeOffset = TestData.SecondStopDateTimeOffset
      }
    }.AsQueryable();

    public BusinessComponentsDalTests() : base(BusinessComponentsDtoTestDataSet)
    {
    }

    [TestInitialize]
    public void Initialize()
    {
      BusinessComponentsDal = new BusinessComponentsDal(MockDbContext.Object);
    }

    #region Update Tests
    [TestMethod]
    [TestCategory("BusinessComponentsDal Update")]
    public async Task Given_ABusinessComponent_When_UpdateIsInvoked_Then_SaveChangesAsyncMethodShouldBeInvokedOnlyOnce()
    {
      await BusinessComponentsDal.Update(new BusinessComponentDto { Id = TestData.FirstValidBusinessComponentId });

      MockDbContext.Verify(m => m.SaveChangesAsync(), Times.Once());
    }

    [TestMethod]
    [TestCategory("BusinessComponentsDal Update")]
    public async Task Given_ABusinessComponent_When_UpdateIsInvoked_Then_ExpectedPropertiesGetUpdatedValues()
    {
      var businessComponentToUpdate = new BusinessComponentDto
      {
        Id = TestData.FirstValidBusinessComponentId,
        StartDateTimeOffset = TestData.SecondStartDateTimeOffset,
        StopDateTimeOffset = TestData.SecondStopDateTimeOffset
      };

      var businessComponentReturned = await BusinessComponentsDal.Update(businessComponentToUpdate);

      Assert.AreEqual(businessComponentToUpdate.StartDateTimeOffset, businessComponentReturned.StartDateTimeOffset);
      Assert.AreEqual(businessComponentToUpdate.StopDateTimeOffset, businessComponentReturned.StopDateTimeOffset);
    }

    [TestMethod]
    [TestCategory("BusinessComponentsDal Update")]
    public async Task Given_ABusinessComponent_When_UpdateIsInvoked_Then_ExpectedPropertiesShouldNotGetUpdatedValues()
    {
      var businessComponentToUpdate = new BusinessComponentDto
      {
        Id = TestData.FirstValidBusinessComponentId,
        StartDateTimeOffset = TestData.SecondStartDateTimeOffset,
        StopDateTimeOffset = TestData.SecondStopDateTimeOffset
      };

      var businessComponentReturned = await BusinessComponentsDal.Update(businessComponentToUpdate);

      Assert.AreEqual(businessComponentReturned.StartDateTimeOffset, TestData.FirstValidBusinessComponentId);
    }
    #endregion
  }
}
