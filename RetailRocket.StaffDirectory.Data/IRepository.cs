using System.Linq;

namespace RetailRocket.StaffDirectory.Data
{
    public interface IRepository
    {
        IQueryable<Staff> Staffs { get; }
        IQueryable<Department> Departments { get; }

        bool CreateDepartment(Department instance);
        bool UpdateDepartment(Department instance);
        bool RemoveDepartment(int departmentId);

        bool CreateStaff(Staff instance);
        bool UpdateStaff(Staff instance);
        bool RemoveStaff(int staffId);

    }
}
