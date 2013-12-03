using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SequencesManager.DataAccess.SqlServer
{
    public class ConnectionProvider
    {
        DbConnection conn;
        string connectionString;
        DbProviderFactory factory;

        // Constructor that retrieves the connectionString from the config file
        public ConnectionProvider()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["MainConnection"].ConnectionString.ToString();
            factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["MainConnection"].ProviderName.ToString());
        }

        public DbConnection GetOpenedConnection()
        {
            conn = factory.CreateConnection();
            conn.ConnectionString = this.connectionString;
            conn.Open();
            return conn;
        }
    }
}
