using System.Collections.Generic;

namespace ModelsClassLibrary.Entitys
{
    public class VehiclesCompany
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string  Address { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
