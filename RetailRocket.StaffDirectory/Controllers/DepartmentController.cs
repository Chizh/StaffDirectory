using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using RetailRocket.StaffDirectory.Data;

namespace RetailRocket.StaffDirectory.Controllers
{
    public class DepartmentController : ControllerBase
    {
        public ActionResult Index()
        {
            return View(new List<Department>(Repository.Departments));
        }

        public ActionResult DepartmentTable()
        {
            return PartialView(new List<Department>(Repository.Departments));
        }
    }
}
