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
        DataLayer data = new DataLayer();

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(data.IsAuthenticated(txtUserName.Text.Trim(), txtPassword.Password))
                {
                    StockWindow sw = new StockWindow();
                    sw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter correct username and password..!!", "Login failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
