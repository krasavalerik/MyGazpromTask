using System.Collections.Generic;

namespace ModelsClassLibrary.Entitys
{
    public class Vehicle
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Mileage { get; set; }
        public bool IsTransit { get; set; }

        public long VehiclesCompanyId { get; set; }
        public VehiclesCompany VehiclesCompany { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
