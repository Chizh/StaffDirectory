using Ninject;

namespace RetailRocket.StaffDirectory.Data.Repository
{
    /// <summary>
    /// Sql ropository of data.
    /// </summary>
    public partial class SqlRepository : IRepository
    {
        /// <summary>
        /// Gets or sets DB context.
        /// </summary>
        [Inject]
        public StaffDirectoryDbDataContext DbContext { get; set; }
    }
}
