using System.Linq;

namespace RetailRocket.StaffDirectory.Data.Repository
{
    public partial class SqlRepository : IRepository // members for Department
    {
        public IQueryable<Department> Departments
        {
            get { return DbContext.Departments; }
        }
        public bool CreateDepartment(Department instance)
        {
            if (instance.ID == 0)
            {
                DbContext.Departments.InsertOnSubmit(instance);
                DbContext.Departments.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateDepartment(Department instance)
        {
            Department departmentStored = DbContext.Departments.FirstOrDefault(d => d.ID == instance.ID);
            if (instance.ID != 0 && departmentStored != null)
            {
                departmentStored.Name = instance.Name;
                DbContext.Departments.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveDepartment(int departmentId)
        {
            Department instance = DbContext.Departments.FirstOrDefault(d => d.ID == departmentId);
            if (instance != null)
            {
                DbContext.Departments.DeleteOnSubmit(instance);
                DbContext.Departments.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
