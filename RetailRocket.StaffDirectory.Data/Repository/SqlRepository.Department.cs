using System;
using System.Linq;
using RetailRocket.StaffDirectory.Data.Exceptions;

namespace RetailRocket.StaffDirectory.Data.Repository
{
    public partial class SqlRepository : IRepository // members for Department
    {
        public IQueryable<Department> Departments
        {
            get { return DbContext.Departments; }
        }

        /// <summary>
        /// Creates a department.
        /// </summary>
        /// <param name="instance">The department which should be created.</param>
        /// <returns>ID if the department created successfully, else -1 or throw EntityExistsException if such department already exists.</returns>
        /// <exception cref="EntityExistsException">Throws EntityExistsException if suc departments already exists.</exception>
        public int CreateDepartment(Department instance)
        {
            var instanceExists =
                DbContext.Departments.FirstOrDefault(d => String.Compare(d.Name, instance.Name, StringComparison.OrdinalIgnoreCase) == 0);
            if (instanceExists != null)
            {
                // if department with such name exists - throw the special exception
                throw new EntityExistsException(string.Format("Department with name '{0}' already exists", instance.Name));
            }

            if (instance.ID == 0)
            {
                DbContext.Departments.InsertOnSubmit(instance);
                DbContext.Departments.Context.SubmitChanges();
                return instance.ID;
            }
            return -1;
        }

        /// <summary>
        /// Updates a department.
        /// </summary>
        /// <param name="instance">The instance of the department which should be updated.</param>
        /// <returns>true if the department updeted successfully, else false.</returns>
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

        /// <summary>
        /// Removes a department with such departmentId.
        /// </summary>
        /// <param name="departmentId">Id of department which should be removed.</param>
        /// <returns>true if department removed successfully, else false.</returns>
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
