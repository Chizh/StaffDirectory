using System;

namespace RetailRocket.StaffDirectory.Data.Exceptions
{
    public class EntityExistsException : Exception
    {
        public EntityExistsException() : base() { }

        public EntityExistsException(string message) : base(message) { }

        public EntityExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
