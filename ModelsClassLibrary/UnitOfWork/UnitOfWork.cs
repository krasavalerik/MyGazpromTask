using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsClassLibrary.Data;
using ModelsClassLibrary.Repositorys;

namespace ModelsClassLibrary.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public IVehiclesCompanyRepository VehiclesCompanys { get; private set; }
        public IVehicleRepository Vehicles { get; private set; }
        public IOrderRepository Orders { get; private set; }

        public UnitOfWork(ApplicationContext applicationContext){
            _context = applicationContext;

            VehiclesCompanys = new VehiclesCompanyRepository(_context);
            Vehicles = new VehicleRepository(_context);
            Orders = new OrderRepository(_context);
        }

        public int Complite(){
            return _context.SaveChanges();
        }

        public void Dispose(){
            _context.Dispose();
        }
    }
}
