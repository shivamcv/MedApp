using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using MedApp.Data;

namespace entityd.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MedDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MedDatabase context)
        {
           
        }
    }
}
