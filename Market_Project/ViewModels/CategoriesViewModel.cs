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
using Market_Project.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Market_Project.ViewModels
{
    public class CategoriesViewModel : BaseViewModel<Category>
    {
        // Services
        private readonly ICategoryService _categoryService;

        // Table data
        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set { _categories = value; OnPropertyChanged(); }
        }

        // Constructor
        public CategoriesViewModel(ICategoryService cs)
        {
            _categoryService = cs; 
            LoadData();
        }



        // Functions
        public async void LoadData()
        {
            var CategoryData = await _categoryService.GetAllAsync();
            Categories = new ObservableCollection<Category>(CategoryData);
        }

        public override void AddNewEntry()
        {
            NewEntry.CreatedAt = DateTime.Now;
            NewEntry.CreatedBy = App.ServiceProvider.GetRequiredService<IActiveUserContext>().Id;

            _categoryService.AddAsync(NewEntry);
            Categories.Add(NewEntry);

            NewEntry = new Category();
        }

        
    }
}
