using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;
using System.Configuration;

namespace RetailRocket.StaffDirectory.Tests.Controllers.API
{
    [TestFixture]
    public class StaffDataControllerTest
    {
        [TestFixtureSetUp]
        public void TestSetup()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["SQLServer_TEST"].ConnectionString;
            string createDbScriptPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\..\DB\01_CreateDB.sql");
            string createDbScript = File.ReadAllText(createDbScriptPath)
                .Replace("RRStaffDirectory", "RRStaffDirectory_TEST");

            SqlConnection conn = new SqlConnection(connectionString);

            Server server = new Server(new ServerConnection(conn));

            server.ConnectionContext.ExecuteNonQuery(createDbScript);
        }

        [Test]
        public void ShouldAddTwoNumbers()
        {
            Assert.That(1, Is.EqualTo(1));
        }
    }
}
