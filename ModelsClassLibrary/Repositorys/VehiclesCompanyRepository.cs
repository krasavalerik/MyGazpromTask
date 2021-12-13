using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelsClassLibrary.Entitys;
using ModelsClassLibrary.Data;

namespace ModelsClassLibrary.Repositorys
{
    public class VehiclesCompanyRepository : Repository<VehiclesCompany>, IVehiclesCompanyRepository
    {
        public ApplicationContext AppContext{
            get { return Context; }
        }

        public VehiclesCompanyRepository(ApplicationContext context) : base(context) { }

        public IEnumerable<Order> GetCompanyOrders(int id){
            return AppContext.Orders
                .Include(v => v.Vehicle)
                .Where(c => c.Vehicle.VehiclesCompanyId == id)
                .ToList();
        }
    }
}
