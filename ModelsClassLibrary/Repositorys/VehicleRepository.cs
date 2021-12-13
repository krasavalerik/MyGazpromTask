using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelsClassLibrary.Data;
using ModelsClassLibrary.Entitys;

namespace ModelsClassLibrary.Repositorys
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public ApplicationContext AppContext{
            get { return Context; }
        }

        public VehicleRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public IEnumerable<Vehicle> GetFreeVehicles(int count){
            return AppContext.Vehicles.Where(v => !v.IsTransit).Take(count).ToList();
        }

        public IEnumerable<Vehicle> GetTransitVehiclesWithCompanys(){
            return AppContext.Vehicles
                .Where(v => v.IsTransit)
                .Include(v => v.VehiclesCompany)
                .OrderBy(v => v.VehiclesCompany.Name)
                .ToList();
        }

        //public override void Delete(Vehicle vehicle){
        //    AppContext.Vehicles.
        //}
    }
}
