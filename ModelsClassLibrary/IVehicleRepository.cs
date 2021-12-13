using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsClassLibrary.Entitys;

namespace ModelsClassLibrary
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetFreeVehicles(int count);
        IEnumerable<Vehicle> GetTransitVehiclesWithCompanys();
    }
}
