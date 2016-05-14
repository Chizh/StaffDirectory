using System;

namespace RetailRocket.StaffDirectory.Entity
{
    public class SearchStaffRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? Birthday { get; set; }
    }
}