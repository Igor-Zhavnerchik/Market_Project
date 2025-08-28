using Market_Project.Data;
using Market_Project.Models;
using Market_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Market_Project.ViewModels
{
    public abstract class BaseViewModel<Item> : INotifyPropertyChanged
        where Item : BaseModel
    {
        public Item SelectedItem { get; set; }

        //functions
        public void SaveDBChanges() 
        {
             App.ServiceProvider.GetRequiredService<IGenericService<Item>>().SaveAsync();
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
