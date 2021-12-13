using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using ModelsClassLibrary.Entitys;
using ModelsClassLibrary.Data;

namespace ModelsClassLibrary.Repositorys
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public ApplicationContext AppContext{
            get { return Context; }
        }

        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public IEnumerable<Order> GetCompliteOrders(int count){
            return AppContext.Orders.Where(o => o.IsComplite).Take(count).ToList();
        }

        public IEnumerable<Order> GetOrdersWithVehicles(int count){
            return AppContext.Orders
                .Include(v => v.Vehicle)
                .OrderBy(v => v.Date)
                .Take(count)
                .ToList();
        }

        public void Edit(Order order){
            AppContext.Orders.Update(order);
        }
    }
}
