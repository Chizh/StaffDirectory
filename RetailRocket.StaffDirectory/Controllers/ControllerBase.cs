using System.Web.Mvc;
using Ninject;
using RetailRocket.StaffDirectory.Data;

namespace RetailRocket.StaffDirectory.Controllers
{
    public abstract class ControllerBase : Controller
    {
        [Inject]
        public IRepository Repository { get; set; }
    }
}
