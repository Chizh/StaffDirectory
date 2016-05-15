using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RetailRocket.StaffDirectory.Data.Exceptions;
using RetailRocket.StaffDirectory.Entity;
using Department = RetailRocket.StaffDirectory.Entity.Department;

namespace RetailRocket.StaffDirectory.Controllers.API
{
    /// <summary>
    /// Api data controller for Department entity.
    /// </summary>
    public class DepartmentDataController : ApiDataControllerBase<Department>
    {
        #region Helper methods
        protected DepartmentResponse GetExceptionResponse(Exception ex)
        {
            return new DepartmentResponse
            {
                StatusCode = 3,
                Message = ex.Message
            };
        }

        protected DepartmentResponse GetGenericResponse(int statusCode, int id, string message)
        {
            return new DepartmentResponse
            {
                StatusCode = statusCode,
                ID = id,
                Message = message
            };
        }
        #endregion

        /// <summary>
        /// Returns list of all of departments without any sorting, paging or conditions.
        /// </summary>
        /// <returns>List of departments.</returns>
        public ICollection<Department> Get()
        {
            var departments = Repository.Departments.ToList();

            List<Department> result = new List<Department>();

            foreach (var department in departments)
            {
                result.Add(new Department
                {
                    ID = department.ID,
                    Name = department.Name
                });
            }

            return result;
        }

        /// <summary>
        /// Creates department.
        /// </summary>
        /// <param name="departmentName">The name of department.</param>
        /// <returns>Response which contains status code, ID if department have been created, or error message.</returns>
        [HttpPost]
        public DepartmentResponse CreateDepartment(string departmentName)
        {
            try
            {
                int result = Repository.CreateDepartment(new Data.Department { Name = departmentName });

                return result > 0
                    ? GetGenericResponse(0, result, null) // Department created successfully
                    : GetGenericResponse(-1, 0, "Department creating failed"); // something wrong
            }
            catch (EntityExistsException ex)
            {
                return GetGenericResponse(2, 0, ex.Message); // the department already exists
            }
            catch (Exception ex)
            {
                return GetExceptionResponse(ex); // something wrong
            }
        }

        /// <summary>
        /// Updates a department.
        /// </summary>
        /// <param name="department">The department which should update.</param>
        /// <returns>Response which contains status code, ID of department, and error message if updating failed.</returns>
        [HttpPost]
        public DepartmentResponse UpdateDepartment(Department department)
        {
            try
            {
                var result = Repository.UpdateDepartment(new Data.Department
                {
                    ID = department.ID,
                    Name = department.Name
                });
                return result
                    ? GetGenericResponse(0, department.ID, null) // the department updated successfully
                    : GetGenericResponse(-1, department.ID, "Such department doesn't exists");
            }
            catch (Exception ex)
            {
                return GetExceptionResponse(ex); // something wrong
            }
        }

        /// <summary>
        /// Removes a department.
        /// </summary>
        /// <param name="departmentId">A department id which should be removed.</param>
        /// <returns>Response which contains a status code, ID of department, and error message if removing failed.</returns>
        [HttpPost]
        public DepartmentResponse RemoveDepartment(int departmentId)
        {
            try
            {
                var result = Repository.RemoveDepartment(departmentId);
                return result
                    ? GetGenericResponse(0, departmentId, null) // the department removed successfully
                    : GetGenericResponse(-1, departmentId, "Such department doesn't exists");
            }
            catch (Exception ex)
            {
                return GetExceptionResponse(ex); // something wrong
            }
        }
    }
}
