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
   public class AboutManager : IAboutManager
   {
      #region Members

      private readonly IDatabaseManager _dbManager;

      #endregion

      #region Constructors

      public AboutManager(IDatabaseManager dbManager)
      {
         if (null == dbManager) {
            throw new Exception();
         }

         _dbManager = dbManager;
      }

      #endregion

      #region Methods - Public

      public AboutDto Create(string value)
      {
         AboutDto dto = new AboutDto { Value = value };

         bool success = _dbManager.CreateHomeAbout(dto);

         if (!success) {
            throw new Exception("Unable to create DTO");
         }

         return dto;
      }

      public bool Delete(int id)
      {
         return _dbManager.DeleteHomeAbout(id);
      }

      public AboutDto Read(int id)
      {
         AboutDto dto = _dbManager.ReadHomeAbout(id);

         if (dto.Value == "test") {
            throw new Exception("Invalid DTO");
         }

         return dto;
      }

      public AboutDto Update(AboutDto dto)
      {
         bool success = _dbManager.UpdateHomeAbout(dto);

         if (!success) {
            throw new Exception("Unable to create DTO");
         }

         return dto;
      }

      #endregion
   }
}