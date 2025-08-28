using Market_Project.Data;
using Market_Project.Models;
using Market_Project.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Market_Project.Views
{
    public partial class ProductList : Page
    {
        private ProductListViewModel viewModel;
        public ProductList(ProductListViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            DataContext = viewModel;      
        }

        private void Button_SaveChanges(object sender, RoutedEventArgs e)
        {
            viewModel.SaveDBChanges();
        }

        private void test( object sender, RoutedEventArgs e)
        {
            viewModel.Products[0].Price = 22;
        }
    }
}
