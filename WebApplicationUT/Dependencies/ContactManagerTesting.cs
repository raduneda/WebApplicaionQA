//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;

using WebApplicationQABL;

using WebApplicationQATL;


namespace WebApplicationUT.Dependencies
{
   /// <summary>
   ///    CRUD
   /// </summary>
   public class ContactManagerTesting : IContactManager
   {


      #region Methods - Public

      public ContactDto Create(string value)
      {
         ContactDto dto = new ContactDto { Value = "testCreateContact" };

         return dto;
      }

      public bool Delete(int id)
      {
         return true;
      }

      public ContactDto Read(int id)
      {
         ContactDto dto = new ContactDto { Value = "testReadContact" };

         return dto;
      }

      public ContactDto Update(ContactDto dto)
      {
         return new ContactDto { Value = "testUpdateContact" };
      }

      #endregion
   }
}