using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Project.Services.Interfaces
{
    internal interface IActiveUserContext
    {
        int Id { get; set; }
        string Name { get; set; }

    }
}
