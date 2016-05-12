using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Ninject;
using RetailRocket.StaffDirectory.App_Start;

namespace RetailRocket.StaffDirectory.Tests
{
    /// <summary>
    /// Provides utilities for tests.
    /// </summary>
    public static class Utils
    {
        private static IKernel _appKernel = null;

        /// <summary>
        /// Gets IKernel instance for Ninject DI.
        /// </summary>
        public static IKernel AppKernel
        {
            get
            {
                if (_appKernel == null)
                {
                    _appKernel = new StandardKernel();
                    NinjectWebCommon.RegisterService(_appKernel,
                        ConfigurationManager.ConnectionStrings["StaffDirectoryConnectionString_TEST"].ConnectionString);
                }
                return _appKernel;
            }
        }

        /// <summary>
        /// Reads string from text embeded resource file.
        /// </summary>
        /// <param name="fileName">Name of the embeded resource file.</param>
        /// <returns>Content of the file.</returns>
        public static string ReadResourceFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Runs sql script at the SQL Server.
        /// </summary>
        /// <param name="script">Code of the script.</param>
        /// <param name="connectionString">Connection string to the SQL Server.</param>
        public static void RunSqlScript(string script, string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            Server server = new Server(new ServerConnection(conn));
            server.ConnectionContext.ExecuteNonQuery(script);
        }
    }
}
