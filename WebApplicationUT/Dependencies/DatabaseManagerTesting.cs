//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using WebApplicationQADL;

using WebApplicationQATL;


namespace WebApplicationUT.Dependencies
{
   public class DatabaseManagerTesting : IDatabaseManager
   {
      #region Interface Members

      public bool CreateHomeAbout(AboutDto value)
      {
         return true;
      }

      public bool CreateHomeContact(ContactDto value)
      {
         return true;
      }

      public bool DeleteHomeAbout(int id)
      {
         return true;
      }

      public bool DeleteHomeContact(int id)
      {
         return true;
      }

      public AboutDto ReadHomeAbout(int id)
      {
         if (id == 1) {
            return new AboutDto();
         }

         return new AboutDto {Id = 10, Value = "test"};
      }

      public ContactDto ReadHomeContact(int id)
      {
        return new ContactDto();
      }

      public bool UpdateHomeAbout(AboutDto contactDto)
      {
         return true;
      }

      public bool UpdateHomeContact(ContactDto contactDto)
      {
         return true;
      }


      #endregion
   }
}