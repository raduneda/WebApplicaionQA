using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;

using NUnit.Framework;

using WebApplicationQABL;

using WebApplicationQADL;

using WebApplicationQATL;

using WebApplicationUT.Dependencies;


namespace WebApplicationUT
{
   [TestFixture]
   class AboutManagerTest
   {
      private IAboutManager _aboutManager;
      private IAboutManager _aboutManagerFalse;
      private IDatabaseManager _databaseManager;
      private IDatabaseManager _databaseManagerFalse;

      [SetUp]
      public void SetUp()
      {
         _databaseManager = new DatabaseManagerTesting();
         _aboutManager = new AboutManager(_databaseManager);

         _databaseManagerFalse = new DatabaseManagerTestingFalse();
         _aboutManagerFalse = new AboutManager( _databaseManagerFalse);
      }

      [Test]
      public void CreateTest()
      {
         AboutDto result = _aboutManager.Create("test");

         Assert.AreEqual("test", result.Value);
         Assert.AreEqual( 0,result.Id);
      }

      [Test]
      public void CreateExceptionTest()
      {
         Exception result = null;

         try {
            _aboutManagerFalse.Create("test");
         } catch (Exception ex) {
            result = ex;
         }

         Assert.IsNotNull(result);
         Assert.AreEqual(typeof(Exception), result.GetType());
         Assert.AreEqual("Unable to create DTO", result.Message);
      }

      [Test]
      public void CreateException2Test()
      {
         Exception result = Assert.Throws<Exception>(() => _aboutManagerFalse.Create("test"));
         Assert.AreEqual("Unable to create DTO", result.Message);
      }

      [Test]
      public void DeleteTrueTest()
      {
         bool result = _aboutManager.Delete(1);
         Assert.IsTrue(result);
      }

      [Test]
      public void DeleteFalseTest()
      {
         bool result = _aboutManagerFalse.Delete(1);
         Assert.False(result);
      }

      [Test]
      public void ReadTest()
      {
         AboutDto result = _aboutManager.Read(1);

         Assert.IsNotNull(result);
         Assert.AreEqual(0, result.Id);
         Assert.IsNull( result.Value);
      }

      [Test]
      public void ReadExceptionTest()
      {
         Exception result = Assert.Throws<Exception>(() => _aboutManager.Read(2));
         Assert.AreEqual("Invalid DTO", result.Message);
      }

      [Test]
      public void UpdateTest()
      {
         //arrange
         Mock<IDatabaseManager> mockDbManager = new Mock<IDatabaseManager>();
         mockDbManager.Setup(m => m.UpdateHomeAbout(It.IsAny<AboutDto>())).Returns(true);

         AboutDto testDto = new AboutDto { Id = 1, Value = "test" };

         _aboutManager = new AboutManager(mockDbManager.Object);

         //Act
         AboutDto resultDto = _aboutManager.Update(testDto);

         //Assert
         Assert.AreEqual(testDto.Id,resultDto.Id);
         Assert.AreEqual(testDto.Value, resultDto.Value);
      }

      [Test]
      public void UpdateExceptionTest()
      {
         //arrange
         Mock<IDatabaseManager> mockDbManager = new Mock<IDatabaseManager>();
         mockDbManager.Setup(m => m.UpdateHomeAbout(It.IsAny<AboutDto>())).Throws(new Exception());

         AboutDto testDto = new AboutDto { Id = 1, Value = "test" };

         _aboutManager = new AboutManager(mockDbManager.Object);

         //Act
         Assert.Throws<Exception>(()=> _aboutManager.Update(testDto));

         mockDbManager.Verify(m => m.UpdateHomeAbout(It.IsAny<AboutDto>()),Times.Exactly(1));
      }
   }
}
