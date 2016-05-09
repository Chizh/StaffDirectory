using Ninject;

namespace RetailRocket.StaffDirectory.Data.Repository
{
    public partial class SqlRepository : IRepository
    {
        [Inject]
        public StaffDirectoryDbDataContext DbContext { get; set; }
    }
}
