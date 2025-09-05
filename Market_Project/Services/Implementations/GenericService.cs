using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Market_Project.Data;
using Market_Project.Services.Interfaces;
using Market_Project.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Windows;

namespace Market_Project.Services.Implementations
{
    public class GenericService<ModelType> : IGenericService<ModelType>
        where ModelType : BaseModel
    {
        protected readonly AppDbContext _db;

        public GenericService(AppDbContext db) { _db = db; }

        public Task<List<ModelType>> GetAllAsync() => _db.Set<ModelType>().ToListAsync();
        public Task SaveAsync() => _db.SaveChangesAsync();
        public async Task AddAsync(ModelType newEntry) => await _db.Set<ModelType>().AddAsync(newEntry);
    }
}

