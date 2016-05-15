using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RetailRocket.StaffDirectory.Data.Exceptions;
using RetailRocket.StaffDirectory.Entity;
using Staff = RetailRocket.StaffDirectory.Entity.Staff;

namespace RetailRocket.StaffDirectory.Controllers.API
{
    /// <summary>
    /// Api data controller for Staff entity.
    /// </summary>
    public class StaffDataController : ApiDataControllerBase<Staff>
    {
        #region Helper methods
        protected StaffResponse GetExceptionResponse(Exception ex)
        {
            return new StaffResponse
            {
                StatusCode = 3,
                Message = ex.Message
            };
        }

        protected StaffResponse GetGenericResponse(int statusCode, int id, string message)
        {
            return new StaffResponse
            {
                StatusCode = statusCode,
                ID = id,
                Message = message
            };
        }
        #endregion

        /// <summary>
        /// Gets collection of Staff without any conditions.
        /// </summary>
        /// <returns>List of Staff.</returns>
        public ICollection<Staff> Get()
        {
            var staffs = Repository.SearchStaff(null, null, null, null, null);

            List<Staff> result = new List<Staff>();

            foreach (var staff in staffs)
            {
                result.Add(new Staff
                {
                    ID = staff.ID,
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    MiddleName = staff.MiddleName,
                    Birthday = staff.Birthday,
                    DepartmentID = staff.DepartmentID,
                    DepartmentName = staff.DepartmentName
                });
            }

            return result;
        }

        /// <summary>
        /// Creates Staff.
        /// </summary>
        /// <param name="instance">The staff instance.</param>
        /// <returns>Response which contains a status code, ID if staff have been created or error message.</returns>
        [HttpPost]
        public StaffResponse CreateStaff(Staff instance)
        {
            try
            {
                int result = Repository.CreateStaff(new Data.Staff
                {   
                    ID = instance.ID,
                    FirstName = instance.FirstName,
                    LastName = instance.LastName,
                    MiddleName = instance.MiddleName,
                    Birthday = instance.Birthday,
                });

                return result > 0
                    ? GetGenericResponse(0, result, null) // Staff created successfully
                    : GetGenericResponse(-1, 0, "Staff creation failed"); // something wrong
            }
            catch (EntityExistsException ex)
            {
                return GetGenericResponse(2, 0, ex.Message); // the staff already exists
            }
            catch (Exception ex)
            {
                return GetExceptionResponse(ex); // something wrong
            }
        }

        /// <summary>
        /// Updates the staff.
        /// </summary>
        /// <param name="staff">Staff instance to update.</param>
        /// <returns>Response which contains a status code, ID of staff, and error message if updating failed.</returns>
        [HttpPost]
        public StaffResponse UpdateStaff(Staff staff)
        {
            try
            {
                var result = Repository.UpdateStaff(new Data.Staff
                {
                    ID = staff.ID,
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    MiddleName = staff.MiddleName,
                    Birthday = staff.Birthday
                });
                return result
                    ? GetGenericResponse(0, staff.ID, null) // the department updated successfully
                    : GetGenericResponse(-1, staff.ID, "Such staff doesn't exists");
            }
            catch (Exception ex)
            {
                return GetExceptionResponse(ex); // something wrong
            }
        }

        /// <summary>
        /// Links staff to departments.
        /// </summary>
        /// <param name="request">Instance of object which contains staffId and departmentIds.</param>
        /// <returns>Response which contains a status code, ID of staff, and error message if updating failed.</returns></returns>
        [HttpPost]
        public StaffResponse LinkStaffToDepartments(StaffLinkRequest request)
        {
            try
            {
                var result = Repository.LinkStaffToDepartments(request.StaffID, request.DepartmentIds);
                return result
                    ? GetGenericResponse(0, request.StaffID, null)
                    : GetGenericResponse(-1, request.StaffID, "Unable to link staff with such departments");
            }
            catch (Exception ex)
            {
                return GetExceptionResponse(ex);
            }
        }

        /// <summary>
        /// Removes a staff.
        /// </summary>
        /// <param name="staffId">A staff id which should be removed.</param>
        /// <returns>Response which contains a status code, ID of the staff, and error message if removing failed.</returns>
        [HttpPost]
        public StaffResponse RemoveStaff(int staffId)
        {
            try
            {
                var result = Repository.RemoveStaff(staffId);
                return result
                    ? GetGenericResponse(0, staffId, null) // the department removed successfully
                    : GetGenericResponse(-1, staffId, "Such staff doesn't exists");
            }
            catch (Exception ex)
            {
                return GetExceptionResponse(ex); // something wrong
            }
        }

        /// <summary>
        /// Searchs staffs by firstName, lastName, middleName, birthday and department.
        /// </summary>
        /// <param name="request">Request which contains fields.</param>
        /// <returns>The result of search.</returns>
        [HttpPost]
        public ICollection<SearchStaff> SearchStaff(SearchStaffRequest request)
        {
            var data = request != null
                ? Repository.SearchStaff(request.FirstName, request.LastName, request.MiddleName,
                    request.Birthday, request.DepartmentID)
                : Repository.SearchStaff(null, null, null, null, null);

            List<SearchStaff> result = new List<SearchStaff>();
            foreach (var searchStaffResult in data)
            {
                result.Add(new SearchStaff
                {
                    ID = searchStaffResult.ID,
                    FirstName = searchStaffResult.FirstName,
                    LastName = searchStaffResult.LastName,
                    MiddleName = searchStaffResult.MiddleName,
                    Birthday = searchStaffResult.Birthday,
                    DepartmentID = searchStaffResult.DepartmentID,
                    DepartmentName = searchStaffResult.DepartmentName
                });
            }
            return result;
        } 
    }
}
