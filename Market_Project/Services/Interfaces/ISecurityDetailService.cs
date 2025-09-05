using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market_Project.Models;

namespace Market_Project.Services.Interfaces
{
    public interface ISecurityDetailService : IGenericService<SecurityDetail>
    {
        Task<SecurityDetail?> GetSecurityDetail(string _login);
    }
}
