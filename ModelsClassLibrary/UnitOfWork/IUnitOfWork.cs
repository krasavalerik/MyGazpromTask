using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsClassLibrary.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IVehiclesCompanyRepository VehiclesCompanys { get; }
        IVehicleRepository Vehicles { get; }
        IOrderRepository Orders { get; }
        int Complite();
    }
}
