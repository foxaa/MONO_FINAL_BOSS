using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL;

namespace Project.DAL.Common
{
    public interface IVehicleMake
    {
        Guid id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
