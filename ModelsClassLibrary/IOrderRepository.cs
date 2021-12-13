using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsClassLibrary.Entitys;

namespace ModelsClassLibrary
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersWithVehicles(int count);
        IEnumerable<Order> GetCompliteOrders(int count);
        void Edit(Order order);
    }
}
