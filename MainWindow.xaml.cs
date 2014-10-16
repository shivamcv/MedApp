using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using MedApp.Data;
using MedApp.Model;

namespace MedApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                using (var db = new MedDatabase())
                {
                    //add
                    db.Medicines.Add(new Medicine() { Name = "digine" + new Random().Next(1,100), Price = 50 });
                    db.SaveChanges();

                    //get
                    lstDemo.ItemsSource = db.Medicines.Select(p => p.Name).ToList();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
