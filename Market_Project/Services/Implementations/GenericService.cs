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
    public class GenericService<T> : IGenericService<T>
        where T : BaseModel
    {
        protected readonly AppDbContext _db;

        public GenericService(AppDbContext db) { _db = db; }

        public Task<List<T>> GetAllAsync() => _db.Set<T>().ToListAsync();
        public Task SaveAsync() => _db.SaveChangesAsync();
        public async Task AddAsync(T newEntry) => await _db.Set<T>().AddAsync(newEntry);
    }
}

