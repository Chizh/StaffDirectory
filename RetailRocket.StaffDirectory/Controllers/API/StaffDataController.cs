using System.Collections.Generic;
using System.Linq;
using RetailRocket.StaffDirectory.Data;

namespace RetailRocket.StaffDirectory.Controllers.API
{
    /// <summary>
    /// Api data controller for Staff entity.
    /// </summary>
    public class StaffDataController : ApiDataControllerBase<Staff>
    {
        public override ICollection<Staff> Get()
        {
            return Repository.Staffs.ToList();
        }
    }
}
