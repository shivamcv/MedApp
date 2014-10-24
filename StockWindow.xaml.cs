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
using System.Windows.Shapes;

namespace MedApp
{
    /// <summary>
    /// Interaction logic for StockWindow.xaml
    /// </summary>
    public partial class StockWindow : Window
    {
        public StockWindow()
        {
            InitializeComponent();
            WindowState = System.Windows.WindowState.Maximized;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
        }
        private void AddStockShow(object sender, RoutedEventArgs e)
        {
        }
        private void ViewStockShow(object sender, RoutedEventArgs e)
        {
        }
    }
}
