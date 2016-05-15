using System;
using System.Collections.Generic;
using System.Web.Http;
using Ninject;
using RetailRocket.StaffDirectory.Data;
using RetailRocket.StaffDirectory.Entity;

namespace RetailRocket.StaffDirectory.Controllers.API
{
    /// <summary>
    /// Base ApiController.
    /// </summary>
    public abstract class ApiDataControllerBase<T> : ApiController
    {
        #region Helper methods
        protected ApiResponse GetExceptionResponse(Exception ex)
        {
            return new ApiResponse
            {
                StatusCode = 3,
                Message = ex.Message
            };
        }

        protected ApiResponse GetGenericResponse(int statusCode, int id, string message)
        {
            return new ApiResponse
            {
                StatusCode = statusCode,
                ID = id,
                Message = message
            };
        }
        #endregion

        [Inject]
        public IRepository Repository { get; set; }
    }
}