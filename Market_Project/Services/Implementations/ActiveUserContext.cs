using Market_Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Project.Services.Implementations
{
    internal class ActiveUserContext : IActiveUserContext
    {
        public int Id { get; set; }
    }
}
