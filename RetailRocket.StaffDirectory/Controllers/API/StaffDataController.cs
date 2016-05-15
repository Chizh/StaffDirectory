using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RetailRocket.StaffDirectory.Data;
using RetailRocket.StaffDirectory.Data.Exceptions;
using RetailRocket.StaffDirectory.Entity;

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
        public override ICollection<Staff> Get()
        {
            return Repository.Staffs.ToList();
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
                int result = Repository.CreateStaff(instance);

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
                var result = Repository.UpdateStaff(staff);
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
        /// Searchs staffs by firstName, lastName, middleName and birthday.
        /// </summary>
        /// <param name="request">Request which contains fields.</param>
        /// <returns>The result of search.</returns>
        [HttpPost]
        public ICollection<Staff> SearchStaff(SearchStaffRequest request)
        {
            return request != null
                ? Repository.SearchStaff(request.FirstName, request.LastName, request.MiddleName,
                    request.Birthday)
                : Repository.SearchStaff(null, null, null, null);
        } 
    }
}
