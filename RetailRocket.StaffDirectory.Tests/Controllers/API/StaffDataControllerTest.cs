using NUnit.Framework;
using RetailRocket.StaffDirectory.Entity;
using Staff = RetailRocket.StaffDirectory.Entity.Staff;

namespace RetailRocket.StaffDirectory.Tests.Controllers.API
{
    /// <summary>
    /// Tests StaffDataController.
    /// </summary>
    [TestFixture]
    public class StaffDataControllerTest : ApiControllerTestBase
    {
        [Test]
        public void ShouldSuccessExecuteGet()
        {
            var result = StaffDataController.Get();
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count);
        }

        [Test]
        [TestCase(0, "Test1", "Test1", "Test1",  Result = 0)] // success
        [TestCase(2, "Test2", "Test2", "Test2", Result = -1)] // id != 0
        [TestCase(0, null, "Test3", "Test3", Result = 3)] // something wrong - firstName it's a required field
        [TestCase(0, "Test4", null, null, Result = 0)] // success
        public int CreateStaffTest(int id, string firstName, string lastName, string middleName)
        {
            var result = StaffDataController.CreateStaff(new Staff
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName
            });
            return result.StatusCode;
        }

        [Test]
        [TestCase(1, "Test1", "Test1", "Test1",  Result = 0)] // success
        [TestCase(0, "Test2", "Test2", "Test2", Result = -1)] // such department doesn't exists
        [TestCase(2, null, "Test3", "Test3", Result = 3)] // something wrong
        public int UpdateStaffTest(int id, string firstName, string lastName, string middleName)
        {
            TestSetup();
            var result = StaffDataController.UpdateStaff(new Staff
            {
                ID = id,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName
            });
            return result.StatusCode;
        }

        [Test]
        [TestCase(1, Result = 0)] // success
        [TestCase(0, Result = -1)] // doesn't exists
        [TestCase(9999, Result = -1)] // doesn't exists
        public int RemoveStaffTest(int staffId)
        {
            var result = StaffDataController.RemoveStaff(staffId);
            return result.StatusCode;
        }

        [Test]
        [TestCase("серг", null, null, Result = 1)]
        [TestCase("sss", null, null, Result = 0)]
        [TestCase(null, "СУР", null, Result = 1)]
        [TestCase(null, null, null, Result = 4)]
        public int SearchStaffTest(string firstName, string lastName, string middleName)
        {
            TestSetup();
            var result = StaffDataController.SearchStaff(new SearchStaffRequest
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName
            }).Count;

            return result;
        }

        [Test]
        [TestCase(4, 1, 2, Result = 0)]
        [TestCase(0, 1, 2, Result = -1)]
        [TestCase(9999, 1, 2, Result = 3)]
        [TestCase(-1, 1, 2, Result = -1)]
        [TestCase(2, 585, 2, Result = 3)]
        public int LinkStaffToDepartmentsTest(int staffID, params int[] departmentIds)
        {
            var result = StaffDataController.LinkStaffToDepartments(new StaffLinkRequest
            {
                StaffID = staffID,
                DepartmentIds = departmentIds
            });
            return result.StatusCode;
        }
    }
}
