//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;
using System.Web;
using System.Web.Mvc;

using WebApplicationQA.Models;

using WebApplicationQABL;

using WebApplicationQADL;


namespace WebApplicationQA.Controllers
{
   public class HomeController : BaseController
   {
      #region Members

      private readonly IAboutManager _aboutManager;
      private readonly IContactManager _contactManager;
      private readonly VirtualManager _virtualManager;

      #endregion

      #region Constructors

      public HomeController()
      {
         _aboutManager = new AboutManager(new DatabaseManager());
         _contactManager = new ContactManager(new DatabaseManager());
         _virtualManager = new VirtualManager();
      }

      public HomeController(HttpContextBase httpContextBase, IAboutManager aboutManager, IContactManager contactManager, VirtualManager virtualManager)
         : base(httpContextBase)
      {
         if (null == aboutManager) {
            throw new ArgumentNullException(nameof(aboutManager));
         }

         if (null == contactManager) {
            throw new ArgumentNullException(nameof(contactManager));
         }

         if (null == virtualManager) {
            throw new ArgumentNullException(nameof(virtualManager));
         }

         _aboutManager = aboutManager;
         _contactManager = contactManager;
         _virtualManager = virtualManager;
      }

      #endregion

      #region Methods - Public

      public ActionResult About()
      {
         HomeViewModel homeViewModel = new HomeViewModel { About = _aboutManager.Read(0) };

         return View(homeViewModel);
      }

      public ActionResult Contact()
      {
         HomeViewModel homeViewModel = new HomeViewModel { Contact = _contactManager.Read(0) };

         return View(homeViewModel);
      }

      public ActionResult Index()
      {
         _aboutManager.Create("Your application description page.");

         _contactManager.Create("Your contact page.");

         return View();
      }

      public ActionResult UserAgent()
      {
         HomeViewModel homeViewModel = new HomeViewModel { Browser = _contextBase.Request.UserAgent, Virtual = _virtualManager.Read() };
         return View(homeViewModel);
      }

      #endregion
   }
}