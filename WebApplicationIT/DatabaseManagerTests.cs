using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using WebApplicationQADL;

using WebApplicationQATL;


namespace WebApplicationIT
{
   [TestFixture]
   public class DatabaseManagerTests
   {
      [Test]
      public void TestCreateHomeAbout()
      {
         DatabaseManager databaseManager = new DatabaseManager();
            AboutDto aboutDto = new AboutDto();
            aboutDto.Id = 2;
            aboutDto.Value = "value";

         _createdDtoList.Add(aboutDto);

            bool result = databaseManager.CreateHomeAbout(aboutDto);

            Assert.IsTrue(result);

            AboutDto resultDto = databaseManager.ReadHomeAbout(0);

            Assert.AreEqual(aboutDto.Id, resultDto.Id);
            Assert.AreEqual(aboutDto.Value, resultDto.Value);
      }

      private readonly List<AboutDto> _createdDtoList = new List<AboutDto>();

      [TearDown]
      public void TearDown()
      {
         DatabaseManager databaseManager = new DatabaseManager();

         for (int i = 0; i < _createdDtoList.Count; i++) {
            databaseManager.DeleteHomeAbout(i);
         }
         
      }

      [Test]
      public void TestCreateHomeAbout2()
      {
         DatabaseManager databaseManager = new DatabaseManager();
            AboutDto aboutDto = new AboutDto();
            aboutDto.Id = 3;
            aboutDto.Value = "value";

         AboutDto aboutDto2 = new AboutDto();
         aboutDto2.Id = 3;
         aboutDto2.Value = "value";

         _createdDtoList.Add(aboutDto);

            bool result = databaseManager.CreateHomeAbout(aboutDto);
         databaseManager.CreateHomeAbout(aboutDto2);

         Assert.IsTrue(result);

            AboutDto resultDto = databaseManager.ReadHomeAbout(1);

            Assert.AreEqual(aboutDto.Id, resultDto.Id);
            Assert.AreEqual(aboutDto.Value, resultDto.Value);
      }
   }
}
