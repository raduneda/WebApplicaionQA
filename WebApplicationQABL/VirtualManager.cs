//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using WebApplicationQATL;


namespace WebApplicationQABL
{
   /// <summary>
   ///    CRUD
   /// </summary>
   public class VirtualManager
   {
      #region Methods - Public

      private static readonly VirtualDto VIRTUAL_DTO = new VirtualDto();

      public VirtualDto Read()
      {
         return VIRTUAL_DTO;
      }

      #endregion
   }
}