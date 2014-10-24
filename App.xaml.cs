using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.IO;
using System.Data.Entity;
using entityd.Migrations;
using MedApp.Data;
using MedApp.Migrations;

namespace MedApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static string StorageLocation { get; set; }

        public App()
        {
            StorageLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedData");

            if(!Directory.Exists(StorageLocation))
            Directory.CreateDirectory(StorageLocation);
         
            AppDomain.CurrentDomain.SetData("DataDirectory", StorageLocation);
            //AppDomain.CurrentDomain.SetData("DataDirectory", Environment.SpecialFolder.CommonApplicationData);
            ShifaDB.CreateDBFile();

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShifaDB, Configuration>());
        }
    }
}
