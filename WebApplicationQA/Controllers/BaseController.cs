//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;
using System.Web;
using System.Web.Mvc;


namespace WebApplicationQA.Controllers
{
   public class BaseController : Controller
   {
      #region Members

      protected HttpContextBase _contextBase;

      #endregion

      #region Constructors

      public BaseController()
      {
         _contextBase = new HttpContextWrapper(System.Web.HttpContext.Current);
      }

      public BaseController(HttpContextBase httpContextBase)
      {
         if (null == httpContextBase) {
            throw new ArgumentNullException();
         }

         _contextBase = httpContextBase;
      }

      #endregion
   }
}