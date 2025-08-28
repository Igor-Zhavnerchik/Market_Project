using Market_Project.Data;
using Market_Project.Models;
using Market_Project.Services.Implementations;
using Market_Project.Services.Interfaces;
using Market_Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Market_Project.ViewModels
{
    public class CategoriesViewModel : BaseViewModel<Category>
    {
        // services
        private readonly ICategoryService _categoryService;

        // table data
        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set { _categories = value; OnPropertyChanged(); }
        }

        // constructor
        public CategoriesViewModel(ICategoryService cs)
        {
            _categoryService = cs; 

            LoadData();
        }

        // functions
        public async void LoadData()
        {
            var CategoryData = await _categoryService.GetAllAsync();
            Categories = new ObservableCollection<Category>(CategoryData);
        }
    }
}
