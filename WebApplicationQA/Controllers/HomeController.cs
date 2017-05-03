//  --------------------------------------------------------------------------------------------
//  <Copyright>
//      Copyright © 2004 - 2017 Stabiplan bv. / Stabiplan International bv. All rights reserved.
//  </Copyright>
//  --------------------------------------------------------------------------------------------

using System;
using System.Web.Mvc;

using WebApplicationQA.Models;

using WebApplicationQABL;

using WebApplicationQADL;


namespace WebApplicationQA.Controllers
{
   public class HomeController : Controller
   {
      #region Members

      private readonly IAboutManager _aboutManager;
      private readonly IContactManager _contactManager;

      #endregion

      #region Constructors

      public HomeController() : this(new AboutManager(new DatabaseManager()), new ContactManager(new DatabaseManager()))
      {
      }

      public HomeController(IAboutManager aboutManager, IContactManager contactManager)
      {
         if (null == aboutManager) {
            throw new ArgumentNullException(nameof(aboutManager));
         }

         if (null == contactManager) {
            throw new ArgumentNullException(nameof(contactManager));
         }

         _aboutManager = aboutManager;
         _contactManager = contactManager;
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

      #endregion
   }
}