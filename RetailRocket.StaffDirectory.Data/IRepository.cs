﻿using System.Linq;

namespace RetailRocket.StaffDirectory.Data
{
    /// <summary>
    /// Data repository interface which declares properties and operations with data.
    /// </summary>
    public interface IRepository
    {
        #region Properties
        /// <summary>
        /// Gets list of Staffs.
        /// </summary>
        IQueryable<Staff> Staffs { get; }
        /// <summary>
        /// Gets list of Departments.
        /// </summary>
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
