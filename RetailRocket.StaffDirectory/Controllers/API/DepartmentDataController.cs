using System.Collections.Generic;
using System.Linq;
using RetailRocket.StaffDirectory.Data;

namespace RetailRocket.StaffDirectory.Controllers.API
{
    /// <summary>
    /// Api data controller for Department entity.
    /// </summary>
    public class DepartmentDataController : ApiDataControllerBase<Department>
    {
        public override ICollection<Department> Get()
        {
            return Repository.Departments.ToList();
        }
    }
}
