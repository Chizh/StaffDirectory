using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Ninject.Infrastructure.Language;

namespace RetailRocket.StaffDirectory.Data.Repository
{
    public partial class SqlRepository : IRepository // members for Staff
    {
        public IQueryable<Staff> Staffs
        {
            get { return DbContext.Staffs; }
        }

        public int CreateStaff(Staff instance)
        {
            if (instance.ID == 0)
            {
                DbContext.Staffs.InsertOnSubmit(instance);
                DbContext.Staffs.Context.SubmitChanges();
                return instance.ID;
            }
            return -1;
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

        public ICollection<Staff> SearchStaff(string firstName, string lastName, string middleName, DateTime? birthday)
        {   
            var searchResult = DbContext.SearchStaff(firstName, lastName, middleName, birthday);
            List<Staff> result = new List<Staff>();
            foreach (var sr in searchResult)
            {
                IQueryable<DepartmentMember> dms = DbContext.DepartmentMembers.Where(dm => dm.StaffID == sr.ID);
                EntitySet<DepartmentMember> dmEs = new EntitySet<DepartmentMember>();
                if (dms != null && dms.Any()) dmEs.AddRange(dms);
                result.Add(new Staff
                {
                    ID = sr.ID,
                    FirstName = sr.FirstName,
                    LastName = sr.LastName,
                    MiddleName = sr.MiddleName,
                    Birthday = sr.Birthday,
                    DepartmentMembers = dmEs
                });
            }
            return result;
        }

        public bool LinkStaffToDepartments(int staffId, int[] departmentIds)
        {
            if (staffId > 0 && departmentIds.Length > 0)
            {
                foreach (var depId in departmentIds)
                {
                    DbContext.DepartmentMembers.InsertOnSubmit(new DepartmentMember
                    {
                        StaffID = staffId,
                        DepartmentID = depId
                    });
                }
                DbContext.DepartmentMembers.Context.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
