using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsClassLibrary.Entitys;

namespace ModelsClassLibrary
{
    public interface IVehiclesCompanyRepository : IRepository<VehiclesCompany>
    {
        public IEnumerable<Order> GetCompanyOrders(int id);
    }
}
