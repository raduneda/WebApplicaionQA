//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;

using WebApplicationQADL;

using WebApplicationQATL;


namespace WebApplicationQABL
{
   /// <summary>
   ///    CRUD
   /// </summary>
   public class ContactManager : IContactManager
   {
      #region Members

      private readonly IDatabaseManager _dbManager;

      #endregion

      #region Constructors

      public ContactManager(IDatabaseManager dbManager)
      {
         if (null == dbManager) {
            throw new Exception();
         }

         _dbManager = dbManager;
      }

      #endregion

      #region Methods - Public

      public ContactDto Create(string value)
      {
         ContactDto dto = new ContactDto { Value = value };

         bool success = _dbManager.CreateHomeContact(dto);

         if (!success) {
            throw new Exception("Unable to create DTO");
         }

         return dto;
      }

      public bool Delete(int id)
      {
         return _dbManager.DeleteHomeContact(id);
      }

      public ContactDto Read(int id)
      {
         ContactDto dto = _dbManager.ReadHomeContact(id);

         if (dto.Value == "test") {
            throw new Exception("Invalid DTO");
         }

         return dto;
      }

      public ContactDto Update(ContactDto dto)
      {
         bool success = _dbManager.UpdateHomeContact(dto);

         if (!success) {
            throw new Exception("Unable to create DTO");
         }

         return dto;
      }

      #endregion
   }
}