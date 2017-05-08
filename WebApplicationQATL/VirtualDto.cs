//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

namespace WebApplicationQATL
{
   public class VirtualDto
   {
      #region Methods - Public

      public string HardCodedName()
      {
         return "This is the original hard coded name";
      }

      public virtual string VirtualName()
      {
         return "This is the original Name";
      }

      #endregion
   }
}