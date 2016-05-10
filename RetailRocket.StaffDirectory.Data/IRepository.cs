using System.Linq;

namespace RetailRocket.StaffDirectory.Data
{
    // Data repository interface which declares properties and operations with data.
    public interface IRepository
    {
        #region Properties
        // Gets list of Staffs
        IQueryable<Staff> Staffs { get; }
        // Gets list of Departments
        IQueryable<Department> Departments { get; }
        #endregion

        #region Department members
        bool CreateDepartment(Department instance);
        bool UpdateDepartment(Department instance);
        bool RemoveDepartment(int departmentId);
        #endregion

        #region Staff members
        bool CreateStaff(Staff instance);
        bool UpdateStaff(Staff instance);
        bool RemoveStaff(int staffId);
        #endregion
    }
}
