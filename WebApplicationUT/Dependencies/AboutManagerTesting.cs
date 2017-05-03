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
   public class AboutManagerTesting : IAboutManager
   {


      #region Methods - Public

      public AboutDto Create(string value)
      {
         AboutDto dto = new AboutDto { Value = "testCreate" };

         return dto;
      }

      public bool Delete(int id)
      {
         return true;
      }

      public static string ReadValue => "testRead";

      public AboutDto Read(int id)
      {
         AboutDto dto = new AboutDto { Value = ReadValue };

         return dto;
      }

      public AboutDto Update(AboutDto dto)
      {
         return new AboutDto { Value = "testUpdate" };
      }

      #endregion
   }
}