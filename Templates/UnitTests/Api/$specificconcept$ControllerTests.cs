using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using $customnamespace$.Contracts;
using $customnamespace$.DataAccess;
using $customnamespace$.Apis.Config;
using $customnamespace$.Apis.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace $customnamespace$.UnitTests.Api
{
  [TestClass]
  public class $specificconcept$sControllerTests
  {
    private Mock<I$specificconcept$Dal> Mock$specificconcept$Dal { get; set; }
    private $specificconcept$Controller $specificconcept$Controller { get; set; }

    [TestInitialize]
    public void Initialize()
    {
      Mock$specificconcept$Dal = new Mock<I$specificconcept$Dal>();
      $specificconcept$Controller = new $specificconcept$Controller(Mock$specificconcept$Dal.Object)
      {
        Request = new HttpRequestMessage(),
        Configuration = new HttpConfiguration()
      };

      AutoMapperConfig.Configure();
    }

    #region Delete Tests
    [TestMethod]
    [TestCategory("$specificconcept$Api Delete")]
    public async Task Given_A$specificconceptsingularized$Id_When_DeleteIsInvoked_Then_DalReadShouldOnlyBeInvokedOnce()
    {
      Mock$specificconcept$Dal.Setup(m => m.Read(TestData.FirstValid$specificconceptsingularized$Id)).ReturnsAsync(new $specificconceptsingularized$Dto());

      await (await $specificconcept$Controller.Delete(TestData.FirstValid$specificconceptsingularized$Id)).ExecuteAsync(CancellationToken.None);

      Mock$specificconcept$Dal.Verify(m => m.Read(TestData.FirstValid$specificconceptsingularized$Id), Times.Once);
    }

    [TestMethod]
    [TestCategory("$specificconcept$Api Delete")]
    public async Task Given_A$specificconceptsingularized$Id_When_DeleteIsInvoked_Then_DalUpdateShouldOnlyBeInvokedOnce()
    {
      Mock$specificconcept$Dal.Setup(m => m.Read(TestData.FirstValid$specificconceptsingularized$Id)).ReturnsAsync(new $specificconceptsingularized$Dto());
      Mock$specificconcept$Dal.Setup(m => m.Update(It.Is<$specificconceptsingularized$Dto>(d => d.Id == TestData.FirstValid$specificconceptsingularized$Id))).ReturnsAsync(new $specificconceptsingularized$Dto());

      await (await $specificconcept$Controller.Delete(TestData.FirstValid$specificconceptsingularized$Id)).ExecuteAsync(CancellationToken.None);

      Mock$specificconcept$Dal.Verify(m => m.Update(It.IsAny<$specificconceptsingularized$Dto>()), Times.Once);
    }
    #endregion

    #region Post Tests
    //[TestMethod]
    //[TestCategory("$specificconcept$Api Post")]
    //public async Task Given_A$specificconceptsingularized$tWithAnInvalidName_When_PostIsInvoked_Then_ResponseShouldHaveBadRequestStatusAndMessageShouldContainTheReason()
    //{
    //  var response = await (await $specificconcept$Controller.Post(new $specificconceptsingularized$ { Name = TestData.Invalid$specificconceptsingularized$Name })).ExecuteAsync(CancellationToken.None);
    //  dynamic responseContent = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

    //  Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    //  Assert.AreEqual("A $humanizedspecificconceptsingularized$ is required to have a name.", responseContent.Message.ToString());
    //}

    //[TestMethod]
    //[TestCategory("$specificconcept$Api Post")]
    //public async Task Given_A$specificconceptsingularized$WithAnInvalidName_When_PostIsInvoked_Then_CreateShouldNotBeInvoked()
    //{
    //  await (await $specificconcept$Controller.Post(new $specificconceptsingularized$ { Name = TestData.Invalid$specificconceptsingularized$Name })).ExecuteAsync(CancellationToken.None);

    //  Mock$specificconcept$Dal.Verify(m => m.Create(It.IsAny<$specificconceptsingularized$Dto>()), Times.Never);
    //}
    #endregion

    #region Put Tests
    //[TestMethod]
    //[TestCategory("$specificconcept$Api Put")]
    //public async Task Given_A$specificconceptsingularized$WithAnInvalidName_When_PutIsInvoked_Then_ResponseShouldHaveBadRequestStatusAndMessageShouldContainTheReason()
    //{
    //  var response = await (await $specificconcept$Controller.Put(new $specificconceptsingularized$ { Name = TestData.Invalid$specificconceptsingularized$Name })).ExecuteAsync(CancellationToken.None);
    //  dynamic responseContent = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

    //  Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    //  Assert.AreEqual("A $humanizedspecificconceptsingularized$ is required to have a name.", responseContent.Message.ToString());
    //}

    //[TestMethod]
    //[TestCategory("$specificconcept$Api Put")]
    //public async Task Given_A$specificconceptsingularized$WithAnInvalidName_When_PutIsInvoked_Then_UpdateShouldNotBeInvoked()
    //{
    //  await (await $specificconcept$Controller.Put(new $specificconceptsingularized$ { Name = TestData.Invalid$specificconcept$Name })).ExecuteAsync(CancellationToken.None);

    //  Mock$specificconcept$Dal.Verify(m => m.Update(It.IsAny<$specificconceptsingularized$Dto>()), Times.Never);
    //}
    #endregion
  }
}
