using Market_Project.Models;
using Market_Project.Services.Interfaces;
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

        // table data
        private ObservableCollection<Unit> _units;
        public ObservableCollection<Unit> Units
        {
            get => _units;
            set { _units = value; OnPropertyChanged(); }
        }

        // constructor
        public UnitsViewModel(IUnitService us)
        {
            _unitService = us;

            LoadData();
        }

        // functions
        public async void LoadData()
        {
            var UnitsData = await _unitService.GetAllAsync();
            Units = new ObservableCollection<Unit>(UnitsData);
        }
    }
}
