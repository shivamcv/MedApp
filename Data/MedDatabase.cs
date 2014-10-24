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
    public partial class ShifaDB : DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Purchase> Stock { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Dealers> Dealers { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public ShifaDB()
            : base("name=ShifaDB")
        {

        }

        public static void CreateDBFile()
        {
            if (File.Exists(Path.Combine(App.StorageLocation, "ShifaDB.mdf")))
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

                string dbName = getDatabaseName("ShifaDB", list);
                string sql = string.Format(@"
                         CREATE DATABASE
                             [{1}]
                         ON PRIMARY (
                            NAME={1},
                            FILENAME = '{0}\ShifaDB.mdf'
                         )
                         LOG ON (
                             NAME=ShifaDB_Log,
                             FILENAME = '{0}\ShifaDB_Log.ldf'
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
