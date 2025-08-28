using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market_Project.Data;
using Market_Project.Models;
using Market_Project.Services.Interfaces;

namespace Market_Project.Services.Implementations
{
    public class UnitService : GenericService<Unit>, IUnitService
    {
        public UnitService(AppDbContext db) : base(db) { }
    }
}
