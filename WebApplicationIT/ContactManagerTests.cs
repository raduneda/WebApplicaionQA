using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using WebApplicationQABL;

using WebApplicationQADL;

using WebApplicationQATL;


namespace WebApplicationIT
{
   [TestFixture]
   class ContactManagerTests
   {
      private ContactManager _contactManager;
      private DatabaseManager _databaseManager;

      [SetUp]
      public void SetUp()
      {
         _databaseManager = new DatabaseManager();
         _contactManager = new ContactManager(_databaseManager);
      }

      [TearDown]
      public void TearDown()
      {
         _contactManager.Delete(0);
         _contactManager.Delete(1);
      }

      [Test]
      public void CreateTest()
      {
         const string TEST_MESSAGE = "contact";
         ContactDto result = _contactManager.Create(TEST_MESSAGE);

         Assert.AreEqual(0,result.Id);
         Assert.AreEqual(TEST_MESSAGE, result.Value);
      }

      [Test]
      public void CreateTest2()
      {
         const string TEST_MESSAGE = "contact";
         ContactDto result = _contactManager.Create(TEST_MESSAGE);
         ContactDto result2 = _contactManager.Create(TEST_MESSAGE);

         Assert.AreEqual(0, result.Id);
         Assert.AreEqual(TEST_MESSAGE, result.Value);

         Assert.AreEqual(0, result2.Id);
         Assert.AreEqual(TEST_MESSAGE, result2.Value);
      }

      [Test]
      public void ReadTest()
      {
         const string TEST_MESSAGE = "contact2";
         const string TEST_MESSAGE1 = "contact1";
         _contactManager.Create(TEST_MESSAGE);
         _contactManager.Create(TEST_MESSAGE1);

         ContactDto readResult = _contactManager.Read(0);
         ContactDto readResult1 = _contactManager.Read(1);

         Assert.AreEqual(TEST_MESSAGE,readResult.Value);
         Assert.AreEqual(TEST_MESSAGE1, readResult1.Value);
      }

      [Test]
      public void DeleteTest()
      {
         const string TEST_MESSAGE = "contact1";
         _contactManager.Create(TEST_MESSAGE);

         bool resultDelete =_contactManager.Delete(0);

         Assert.IsTrue(resultDelete);

         ContactDto nullValueDto =_contactManager.Read(0);

         Assert.IsNull(nullValueDto.Value);
      }

      [Test]
      public void UpdateTest()
      {
         const string TEST_MESSAGE = "contact";
          _contactManager.Create(TEST_MESSAGE);

         ContactDto updateDto = new ContactDto();
         updateDto.Id = 0;
         updateDto.Value = "updatedValue";

         ContactDto resultUpdatedDto =_contactManager.Update(updateDto);
         Assert.AreEqual(updateDto.Id, resultUpdatedDto.Id);
         Assert.AreEqual(updateDto.Value, resultUpdatedDto.Value);
      }
   }
}
