using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
      private HomeController _homeController;

      [SetUp]
      public void Setup()
      {
         //Arrange
         _homeController = new HomeController(new AboutManagerTesting(), new ContactManagerTesting());
      }

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

      private static AboutDto GetAboutDto(ActionResult result)
      {
         AboutDto resultDto;
         ViewResult viewResult = result as ViewResult;
         HomeViewModel viewModel = viewResult.Model as HomeViewModel;
         resultDto = viewModel.About;
         return resultDto;
      }
   }
}
