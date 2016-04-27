using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Apis;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.Apis.Controllers;
using PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.DataAccess;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.UnitTests.Api
{
  [TestClass]
  public class BusinessComponentsControllerTests
  {
    private Mock<IBusinessComponentsDal> MockBusinessComponentsDal { get; set; }
    private BusinessComponentsController BusinessComponentsController { get; set; }

    [TestInitialize]
    public void Initialize()
    {
      MockBusinessComponentsDal = new Mock<IBusinessComponentsDal>();
      BusinessComponentsController = new BusinessComponentsController(MockBusinessComponentsDal.Object)
      {
        Request = new HttpRequestMessage(),
        Configuration = new HttpConfiguration()
      };

      AutoMapperConfig.Configure();
    }

    #region Delete Tests
    [TestMethod]
    [TestCategory("BusinessComponentsApi Delete")]
    public async Task Given_ABusinessComponentId_When_DeleteIsInvoked_Then_DalReadShouldOnlyBeInvokedOnce()
    {
      MockBusinessComponentsDal.Setup(m => m.Read(TestData.FirstValidBusinessComponentId)).ReturnsAsync(new BusinessComponentDto());

      await (await BusinessComponentsController.Delete(TestData.FirstValidBusinessComponentId)).ExecuteAsync(CancellationToken.None);

      MockBusinessComponentsDal.Verify(m => m.Read(TestData.FirstValidBusinessComponentId), Times.Once);
    }

    [TestMethod]
    [TestCategory("BusinessComponentsApi Delete")]
    public async Task Given_ABusinessComponentId_When_DeleteIsInvoked_Then_DalUpdateShouldOnlyBeInvokedOnce()
    {
      MockBusinessComponentsDal.Setup(m => m.Read(TestData.FirstValidBusinessComponentId)).ReturnsAsync(new BusinessComponentDto());
      MockBusinessComponentsDal.Setup(m => m.Update(It.Is<BusinessComponentDto>(d => d.Id == TestData.FirstValidBusinessComponentId))).ReturnsAsync(new BusinessComponentDto());

      await (await BusinessComponentsController.Delete(TestData.FirstValidBusinessComponentId)).ExecuteAsync(CancellationToken.None);

      MockBusinessComponentsDal.Verify(m => m.Update(It.IsAny<BusinessComponentDto>()), Times.Once);
    }
    #endregion

    #region Post Tests
    //[TestMethod]
    //[TestCategory("BusinessComponentsApi Post")]
    //public async Task Given_ABusinessComponentWithAnInvalidName_When_PostIsInvoked_Then_ResponseShouldHaveBadRequestStatusAndMessageShouldContainTheReason()
    //{
    //  var response = await (await BusinessComponentsController.Post(new BusinessComponent { Name = TestData.InvalidBusinessComponentName })).ExecuteAsync(CancellationToken.None);
    //  dynamic responseContent = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

    //  Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    //  Assert.AreEqual("A business component is required to have a name.", responseContent.Message.ToString());
    //}

    //[TestMethod]
    //[TestCategory("BusinessComponentsApi Post")]
    //public async Task Given_ABusinessComponentWithAnInvalidName_When_PostIsInvoked_Then_CreateShouldNotBeInvoked()
    //{
    //  await (await BusinessComponentsController.Post(new BusinessComponent { Name = TestData.InvalidBusinessComponentName })).ExecuteAsync(CancellationToken.None);

    //  MockBusinessComponentsDal.Verify(m => m.Create(It.IsAny<BusinessComponentDto>()), Times.Never);
    //}
    #endregion

    #region Put Tests
    //[TestMethod]
    //[TestCategory("BusinessComponentsApi Put")]
    //public async Task Given_ABusinessComponentWithAnInvalidName_When_PutIsInvoked_Then_ResponseShouldHaveBadRequestStatusAndMessageShouldContainTheReason()
    //{
    //  var response = await (await BusinessComponentsController.Put(new BusinessComponent { Name = TestData.InvalidBusinessComponentName })).ExecuteAsync(CancellationToken.None);
    //  dynamic responseContent = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

    //  Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    //  Assert.AreEqual("A business component is required to have a name.", responseContent.Message.ToString());
    //}

    //[TestMethod]
    //[TestCategory("BusinessComponentsApi Put")]
    //public async Task Given_ABusinessComponentWithAnInvalidName_When_PutIsInvoked_Then_UpdateShouldNotBeInvoked()
    //{
    //  await (await BusinessComponentsController.Put(new BusinessComponent { Name = TestData.InvalidBusinessComponentName })).ExecuteAsync(CancellationToken.None);

    //  MockBusinessComponentsDal.Verify(m => m.Update(It.IsAny<BusinessComponentDto>()), Times.Never);
    //}
    #endregion
  }
}
