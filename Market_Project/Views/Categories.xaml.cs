using Market_Project.Data;
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
    public partial class Categories : Page
    {
        private CategoriesViewModel viewModel;
        public Categories(CategoriesViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            this.DataContext = viewModel;
        }
    }
}
