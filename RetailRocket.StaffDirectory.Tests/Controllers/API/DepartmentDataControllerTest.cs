using NUnit.Framework;
using RetailRocket.StaffDirectory.Entity;
using RetailRocket.StaffDirectory.Data;
using Department = RetailRocket.StaffDirectory.Entity.Department;

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

        [Test]
        [TestCase(0, "test", Result = 0)] // just a new department
        [TestCase(0, "Бухгалтерия", Result = 2)] // such department already exists
        [TestCase(3, "Бухгалтерия", Result = 2)] // such department already exists
        public int CreateDepartmentTest(int departmentId, string departmentName)
        {
            var result = DepartmentDataController.CreateDepartment(departmentName);
            return result.StatusCode;
        }

        [Test]
        [TestCase(2, "Бух2", Result = 0)] // update existing department
        [TestCase(99999, "Бух2", Result = -1)] // updated a department wich doesn't exist
        public int UpdateDepartmentTest(int departmentId, string departmentName)
        {
            var result = DepartmentDataController.UpdateDepartment(new Department
            {
                ID = departmentId,
                Name = departmentName
            });
            return result.StatusCode;
        }

        [Test]
        [TestCase(9999, Result = -1)] // doesn't exist
        [TestCase(0, Result = -1)] //  doesn't exist
        [TestCase(1, Result = 0)] // success
        public int RemoveDepartment(int departmentId)
        {
            var result = DepartmentDataController.RemoveDepartment(departmentId);
            return result.StatusCode;
        }
    }
}
