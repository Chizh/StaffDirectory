using System.Collections.Generic;
using System.Web.Mvc;
using Department = RetailRocket.StaffDirectory.Entity.Department;

namespace RetailRocket.StaffDirectory.Controllers
{
    public class DepartmentController : ControllerBase
    {
        public ActionResult Index()
        {
            List<Department> result = new List<Department>();
            var deps = Repository.Departments;
            foreach (var department in deps)
            {
                result.Add(new Department
                {
                    ID = department.ID,
                    Name = department.Name
                });
            }
            return View(result);
        }
    }
}
