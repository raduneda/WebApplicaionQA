//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System.Reflection;
using System.Web;
using System.Web.Mvc;

using Moq;

using NUnit.Framework;

using WebApplicationQA.Controllers;
using WebApplicationQA.Models;

using WebApplicationQABL;

using WebApplicationQATL;

using WebApplicationUT.Dependencies;


namespace WebApplicationUT
{
   class HomeControllerTestsMoq : BaseTestClass
   {
      #region Setup/Teardown

      [SetUp]
      public void Setup()
      {
         _mockAboutManager = new Mock<IAboutManager>();
         _mockContactManager = new Mock<IContactManager>();
         _mockHttpContextBase = new Mock<HttpContextBase>();

         //Arrange
         _homeController = new HomeController(_mockHttpContextBase.Object, _mockAboutManager.Object, _mockContactManager.Object, new VirtualManager());
      }

      #endregion

      #region Tests

      [Test]
      public void TestHomeControllerAbout()
      {
         AboutDto aboutDto = new AboutDto();
         aboutDto.Id = 2;
         aboutDto.Value = "test";

         _mockAboutManager.Setup(m=>m.Read(It.IsAny<int>())).Returns(aboutDto).Verifiable();

         //Act
         ActionResult result = _homeController.About();

         _mockAboutManager.VerifyAll();
         _mockAboutManager.Verify(m => m.Read(It.IsAny<int>()), Times.Once);

         //Assert
         AboutDto resultDto = GetAboutDto(result);
         Assert.AreEqual(aboutDto.Value, resultDto.Value);
         Assert.AreEqual(aboutDto.Id, resultDto.Id);
      }

      [Test]
      public void TestHomeControllerContact()
      {
         //Act
         ActionResult result = _homeController.Contact();

         //Assert
         ViewResult viewResult = result as ViewResult;
         HomeViewModel viewModel = viewResult.Model as HomeViewModel;

         ContactDto resultDto = viewModel.Contact;

         Assert.AreEqual("testReadContactt", resultDto.Value);
      }

      [Test]
      public void TestHomeControllerIndex()
      {
         string returnedValueAbout=null;
         string returnedValueContact = null;

         _mockAboutManager.Setup(m => m.Create(It.IsAny<string>())).Callback((string value) => { returnedValueAbout = value; });
         _mockContactManager.Setup(m => m.Create(It.IsAny<string>())).Callback((string value) => { returnedValueContact = value; });

         ViewResult viewResult =  (ViewResult) _homeController.Index();

         _mockAboutManager.VerifyAll();
         _mockContactManager.VerifyAll();

         Assert.AreEqual("Your application description page.", returnedValueAbout);
         Assert.AreEqual("Your contact page.", returnedValueContact);

         Assert.AreEqual("", viewResult.ViewName);
      }

      //public string TestMethod()
      //{
      //   string decistion = string.Empty;

      //   _homeController.methodThatChangesSomething(decistion);

      //   if (decistion == "test") {
      //      // do something
      //   } else {
      //      //do something else
      //   }

      //   return decistion;
      //}

      [Test]
      public void UserAgentTest()
      {
         string userAgent = "Chrome";
         _mockHttpContextBase.Setup(m=>m.Request.UserAgent).Returns(userAgent).Verifiable();

         ViewResult result = (ViewResult) _homeController.UserAgent();

         _mockHttpContextBase.Verify(m => m.Request.UserAgent,Times.Once);

         HomeViewModel resultmodel = (HomeViewModel) result.Model;

         Assert.AreEqual(userAgent,resultmodel.Browser);
      }

      [Test]
      public void UserAgentTest2()
      {
         VirtualManager virtualManager = new VirtualManager();
         FieldInfo fi = virtualManager.GetType().GetField("VIRTUAL_DTO", BindingFlags.NonPublic | BindingFlags.Static);

         Mock<VirtualDto> dto = new Mock<VirtualDto>();
         dto.Setup(m => m.VirtualName()).Returns("virtualName");

         fi.SetValue(null,dto.Object);


         _homeController = new HomeController(_mockHttpContextBase.Object, _mockAboutManager.Object, _mockContactManager.Object, virtualManager);

         string userAgent = "Chrome";
         _mockHttpContextBase.Setup(m => m.Request.UserAgent).Returns(userAgent).Verifiable();

         ViewResult result = (ViewResult) _homeController.UserAgent();

         _mockHttpContextBase.Verify(m => m.Request.UserAgent, Times.Once);

         HomeViewModel resultmodel = (HomeViewModel) result.Model;

         Assert.AreEqual(userAgent, resultmodel.Browser);
         Assert.AreEqual("virtualName", resultmodel.Virtual.VirtualName());
      }

      #endregion

      #region Private Methods

      private HomeController _homeController;
      private Mock<IContactManager> _mockContactManager;
      private Mock<IAboutManager> _mockAboutManager;
      private Mock<HttpContextBase> _mockHttpContextBase;

      private static AboutDto GetAboutDto(ActionResult result)
      {
         AboutDto resultDto;
         ViewResult viewResult = result as ViewResult;
         HomeViewModel viewModel = viewResult.Model as HomeViewModel;
         resultDto = viewModel.About;
         return resultDto;
      }

      #endregion
   }


   public class TestContext : HttpContextBase
   {
      public override HttpRequestBase Request {
         get { return new TestRequest(); } 
      }
   }


   public class TestRequest : HttpRequestBase
   {
      public override string UserAgent {
         get { return "test"; } 
      }
   }
}