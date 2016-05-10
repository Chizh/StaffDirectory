using System.Linq;

namespace RetailRocket.StaffDirectory.Data.Repository
{
    public partial class SqlRepository : IRepository // members for Staff
    {
        public IQueryable<Staff> Staffs
        {
            get { return DbContext.Staffs; }
        }

        public bool CreateStaff(Staff instance)
        {
            if (instance.ID == 0)
            {
                DbContext.Staffs.InsertOnSubmit(instance);
                DbContext.Staffs.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateStaff(Staff instance)
        {
            Staff staffStored = DbContext.Staffs.FirstOrDefault(s => s.ID == instance.ID);
            if (instance.ID != 0 && staffStored != null)
            {
                staffStored.FirstName = instance.FirstName;
                staffStored.LastName = instance.LastName;
                staffStored.MiddleName = instance.MiddleName;
                staffStored.Birthday = instance.Birthday;
                staffStored.DepartmentMembers = instance.DepartmentMembers;
                DbContext.Staffs.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveStaff(int staffId)
        {
            Staff instance = DbContext.Staffs.FirstOrDefault(s => s.ID == staffId);
            if (instance != null)
            {
                DbContext.Staffs.DeleteOnSubmit(instance);
                DbContext.Staffs.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
