using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using MedApp.Model;

namespace MedApp.Data
{
    public partial class MedDatabase : DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
        public MedDatabase()
            : base("name=MedDatabase")
        {

        }

        public static void CreateDBFile()
        {
            if(File.Exists(Path.Combine(App.StorageLocation, "MedDatabase.mdf")))
                return;

            SqlConnection connection = new SqlConnection(@"server=(localdb)\v11.0");
            using (connection)
            {
                connection.Open();

                List<string> list = new List<string>();

                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", connection))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }
                }

                string dbName = getDatabaseName("MedDatabase", list);
                string sql = string.Format(@"
                         CREATE DATABASE
                             [{1}]
                         ON PRIMARY (
                            NAME={1},
                            FILENAME = '{0}\MedDatabase.mdf'
                         )
                         LOG ON (
                             NAME=MedDatabase_Log,
                             FILENAME = '{0}\MedDatabase_Log.ldf'
                         )",
                 System.IO.Path.Combine(App.StorageLocation), dbName
                );

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }

        }
        static int i = 1;
        private static string getDatabaseName(string p, List<string> list)
        {
            if (list.Contains(p))
                return getDatabaseName(p + i++, list);
            else
                return p;
        }
    }
}
