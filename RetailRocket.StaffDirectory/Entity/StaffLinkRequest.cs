namespace RetailRocket.StaffDirectory.Entity
{
    public class StaffLinkRequest
    {
        public int StaffID { get; set; }
        public int[] DepartmentIds { get; set; }
    }
}