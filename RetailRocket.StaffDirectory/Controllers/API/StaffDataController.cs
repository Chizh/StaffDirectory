using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject;
using RetailRocket.StaffDirectory.Data;

namespace RetailRocket.StaffDirectory.Controllers.API
{
    public class StaffDataController : ApiController
    {
        [Inject]
        public IRepository Repository { get; set; }

        public ICollection<Staff> Get()
        {
            return Repository.Staffs.ToList();
        }
    }
}
