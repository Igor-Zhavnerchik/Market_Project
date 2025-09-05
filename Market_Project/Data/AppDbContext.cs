using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market_Project.Models;

namespace Market_Project.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Staff> Staff {  get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<SecurityDetail> SecurityDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
