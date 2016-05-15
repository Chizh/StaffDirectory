using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailRocket.StaffDirectory.Entity
{
    public class Staff
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? Birthday { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}