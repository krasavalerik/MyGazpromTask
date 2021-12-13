using System;

namespace ModelsClassLibrary.Entitys
{
    public class Order
    {
        public long Id { get; set; }
        public string Route { get; set; }
        public bool IsComplite { get; set; }
        public DateTime Date { get; set; }

        public long VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
