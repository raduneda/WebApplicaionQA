//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System.Web.Mvc;

using NUnit.Framework;

using WebApplicationQA.Controllers;
using WebApplicationQA.Models;

using WebApplicationQABL;

using WebApplicationQATL;

using WebApplicationUT.Dependencies;


namespace WebApplicationUT
{
   class HomeControllerTests : BaseTestClass
   {
      #region Setup/Teardown

      [SetUp]
      public void Setup()
      {
         //Arrange
         _homeController = new HomeController(null, new AboutManagerTesting(), new ContactManagerTesting(), new VirtualManager());
      }

      #endregion

      #region Tests

      [Test]
      public void TestHomeControllerAbout()
      {
         //Act
         ActionResult result = _homeController.About();

         //Assert
         AboutDto resultDto = GetAboutDto(result);
         Assert.AreEqual(AboutManagerTesting.ReadValue, resultDto.Value);
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

      #endregion

      #region Private Methods

      private HomeController _homeController;

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
}