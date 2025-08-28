using Market_Project.Data;
using Market_Project.Models;
using Market_Project.Services;
using Market_Project.Services.Interfaces;
using Market_Project.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Market_Project.ViewModels
{
    public class ProductListViewModel : BaseViewModel<Product>
    {
        // services
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IUnitService _unitService;

        // table data
        private ObservableCollection<Product> _products;
        private ObservableCollection<Category> _categories;
        private ObservableCollection<Unit> _units;

        public ObservableCollection<Product> Products
        {
            get => _products;
            set { _products = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set { _categories = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Unit> Units
        {
            get => _units;
            set { _units = value; OnPropertyChanged(); }
        }

        // constructor
        public ProductListViewModel(IProductService ps, ICategoryService cs, IUnitService us)
        {
            _productService = ps;
            _categoryService = cs;
            _unitService = us;

            LoadData();
        }

        // functions
        public async void LoadData()
        {
            var ProductData = await _productService.GetAllAsync();
            var CategoryData = await _categoryService.GetAllAsync();
            var UnitData = await _unitService.GetAllAsync();

            Products = new ObservableCollection<Product>(ProductData);
            Categories = new ObservableCollection<Category>(CategoryData);
            Units = new ObservableCollection<Unit>(UnitData);
        }

    }
}
