using NUnit.Framework;
using Ninject;
using RetailRocket.StaffDirectory.Controllers.API;
using RetailRocket.StaffDirectory.Data;

namespace RetailRocket.StaffDirectory.Tests.Controllers.API
{
    /// <summary>
    /// Tests StaffDataController.
    /// </summary>
    [TestFixture]
    public class DepartmentDataControllerTest : ApiControllerTestBase
    {
        [Test]
        public void ShouldSuccessExecuteGet()
        {
            var result = DepartmentDataController.Get();
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }
    }
}
