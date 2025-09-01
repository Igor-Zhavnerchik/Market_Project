using Market_Project.Models;
using Market_Project.Services.Implementations;
using Market_Project.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Project.ViewModels
{
    public class UnitsViewModel : BaseViewModel<Unit>
    {
        private readonly IUnitService _unitService;

        // Table data
        private ObservableCollection<Unit> _units;
        public ObservableCollection<Unit> Units
        {
            get => _units;
            set { _units = value; OnPropertyChanged(); }
        }

        // Constructor
        public UnitsViewModel(IUnitService us)
        {
            _unitService = us;

            LoadData();
        }

        // Functions
        public async void LoadData()
        {
            var UnitsData = await _unitService.GetAllAsync();
            Units = new ObservableCollection<Unit>(UnitsData);
        }

        public override void AddNewEntry()
        {
            NewEntry.CreatedAt = DateTime.Now;
            NewEntry.CreatedBy = App.ServiceProvider.GetRequiredService<IActiveUserContext>().Id;

            _unitService.AddAsync(NewEntry);
            Units.Add(NewEntry);

            NewEntry = new Unit();
        }
    }
}
