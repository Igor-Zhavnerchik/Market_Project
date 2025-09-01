using Market_Project.Data;
using Market_Project.Models;
using Market_Project.Services.Interfaces;
using Market_Project.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Market_Project.ViewModels
{
    public abstract class BaseViewModel<Item> : INotifyPropertyChanged
        where Item : BaseModel, new()
    {
        public Item SelectedItem { get; set; }
        private Item _newEntry;
        public Item NewEntry
        {
            get => _newEntry;
            set
            {
                _newEntry = value;
                OnPropertyChanged();
            }
        }

        // Commands
        public ICommand SaveCommand { get; set; }
        public ICommand OpenAddFormCommand { get; set; }
        private bool _canOpen = true;

        public ICommand AddCommand { get; set; }


        // Base constructor
        public BaseViewModel()
        {
            SaveCommand = new RelayCommand(_ => SaveDBChanges());
            OpenAddFormCommand = new RelayCommand(_ => OpenAddForm(), _ => _canOpen);
            AddCommand = new RelayCommand(_ => AddNewEntry());
        }

        // Functions
        public void SaveDBChanges() 
        {
             App.ServiceProvider.GetRequiredService<IGenericService<Item>>().SaveAsync();
        }

        public void OpenAddForm()
        {
            _canOpen = false;
            NewEntry ??= new Item();

            var AddFormName = $"Market_Project.Views.{typeof(Item).Name}AddForm"; // workaround
            try
            {
                var AddWindow = (Window)App.ServiceProvider.GetRequiredService(Type.GetType(AddFormName));
                AddWindow.Closed += (s, e) => { _canOpen = true; };

                AddWindow.DataContext = this;
                AddWindow.Show();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public abstract void AddNewEntry();


        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
