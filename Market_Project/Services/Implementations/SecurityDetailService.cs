using Market_Project.Data;
using Market_Project.Models;
using Market_Project.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Project.Services.Implementations
{
    public class SecurityDetailService : GenericService<SecurityDetail>, ISecurityDetailService
    {
        public SecurityDetailService(AppDbContext db) : base(db) { }

        public async Task<SecurityDetail?> GetSecurityDetail(string _login)
        {
            return await _db.SecurityDetails.Where(s => s.Login == _login)
                                            .FirstOrDefaultAsync();
        }
    }
}
