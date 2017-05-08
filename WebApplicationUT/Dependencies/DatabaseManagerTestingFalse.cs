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
   public class DatabaseManagerTestingFalse : IDatabaseManager
   {
      #region Interface Members

      public bool CreateHomeAbout(AboutDto value)
      {
        return false;
      }

      public bool CreateHomeContact(ContactDto value)
      {
        return false;
      }

      public bool DeleteHomeAbout(int id)
      {
        return false;
      }

      public bool DeleteHomeContact(int id)
      {
        return false;
      }

      public AboutDto ReadHomeAbout(int id)
      {
         return new AboutDto();
      }

      public ContactDto ReadHomeContact(int id)
      {
        return new ContactDto();
      }

      public bool UpdateHomeAbout(AboutDto contactDto)
      {
        return false;
      }

      public bool UpdateHomeContact(ContactDto contactDto)
      {
        return false;
      }


      #endregion
   }
}