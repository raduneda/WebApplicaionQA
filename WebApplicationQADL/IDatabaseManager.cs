//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using WebApplicationQATL;


namespace WebApplicationQADL
{
   public interface IDatabaseManager
   {
      #region Methods - Public

      bool CreateHomeAbout(AboutDto value);
      bool CreateHomeContact(ContactDto value);
      bool DeleteHomeAbout(int id);
      bool DeleteHomeContact(int id);
      AboutDto ReadHomeAbout(int id);
      ContactDto ReadHomeContact(int id);
      bool UpdateHomeAbout(AboutDto contactDto);
      bool UpdateHomeContact(ContactDto contactDto);

      #endregion
   }
}