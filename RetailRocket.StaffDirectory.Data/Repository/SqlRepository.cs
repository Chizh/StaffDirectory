using Ninject;

namespace RetailRocket.StaffDirectory.Data.Repository
{
    // Sql ropository of data.
    public partial class SqlRepository : IRepository
    {
        // Gets or sets DB context.
        [Inject]
        public StaffDirectoryDbDataContext DbContext { get; set; }
    }
}
