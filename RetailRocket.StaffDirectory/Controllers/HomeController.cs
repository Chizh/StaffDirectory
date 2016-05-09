using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using RetailRocket.StaffDirectory.Data;

namespace RetailRocket.StaffDirectory.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [Inject]
        public IRepository Repository { get; set; }

        public ActionResult Index()
        {
            return View();
        }

    }
}
