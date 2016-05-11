using System.Collections.Generic;
using System.Web.Http;
using Ninject;
using RetailRocket.StaffDirectory.Data;

namespace RetailRocket.StaffDirectory.Controllers.API
{
    /// <summary>
    /// Base ApiController.
    /// </summary>
    public abstract class ApiDataControllerBase<T> : ApiController
    {
        [Inject]
        public IRepository Repository { get; set; }

        public abstract ICollection<T> Get();
    }
}