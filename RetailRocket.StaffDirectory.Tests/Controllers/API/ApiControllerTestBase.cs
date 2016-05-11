using System.Configuration;
using Ninject;
using NUnit.Framework;

namespace RetailRocket.StaffDirectory.Tests.Controllers.API
{
    public  abstract class ApiControllerTestBase
    {
        public static IKernel AppKernel;

        /// <summary>
        /// Setups for the all of the tests.
        /// Recreate test data base.
        /// </summary>
        [TestFixtureSetUp]
        public virtual void TestSetup()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["SQLServer_TEST"].ConnectionString;
            string script = Utils.ReadResourceFile("RetailRocket.StaffDirectory.Tests.Data.01_CreateDB.sql")
                .Replace("RRStaffDirectory", "RRStaffDirectory_TEST");
            Utils.RunSqlScript(script, connectionString);

            connectionString =
                ConfigurationManager.ConnectionStrings["StaffDirectoryConnectionString_TEST"].ConnectionString;
            script = Utils.ReadResourceFile("RetailRocket.StaffDirectory.Tests.Data.02_CreateStructure.sql");
            Utils.RunSqlScript(script, connectionString);

            script = Utils.ReadResourceFile("RetailRocket.StaffDirectory.Tests.Data.03_StoredProcedures.sql");
            Utils.RunSqlScript(script, connectionString);

            script = Utils.ReadResourceFile("RetailRocket.StaffDirectory.Tests.Data.04_SampleData.sql");
            Utils.RunSqlScript(script, connectionString);
        }
    }
}
