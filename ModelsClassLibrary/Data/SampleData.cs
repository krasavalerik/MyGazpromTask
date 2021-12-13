using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsClassLibrary.Entitys;

namespace ModelsClassLibrary.Data
{
    public static class SampleData
    {
        public static void Initialize(ApplicationContext applicationContext){

            if (!applicationContext.VehiclesCompanies.Any()){
                applicationContext.VehiclesCompanies.AddRange(
                    new VehiclesCompany
                    {
                        Name = "company1",
                        Address = "street1"
                    },
                    new VehiclesCompany
                    {
                        Name = "company2",
                        Address = "street2"
                    },
                    new VehiclesCompany
                    {
                        Name = "company3",
                        Address = "street3"
                    }
                    );
                applicationContext.SaveChanges();
            }

            if (!applicationContext.Vehicles.Any()){
                applicationContext.Vehicles.AddRange(
                    new Vehicle
                    {
                        Brand = "car1",
                        Mileage = "10",
                        IsTransit = true,
                        VehiclesCompanyId = 1
                    },
                    new Vehicle
                    {
                        Brand = "car2",
                        Mileage = "20",
                        IsTransit = true,
                        VehiclesCompanyId = 1
                    },
                    new Vehicle
                    {
                        Brand = "car3",
                        Mileage = "30",
                        IsTransit = true,
                        VehiclesCompanyId = 2
                    },
                    new Vehicle
                    {
                        Brand = "car4",
                        Mileage = "40",
                        IsTransit = false,
                        VehiclesCompanyId = 2
                    },
                    new Vehicle
                    {
                        Brand = "cars5",
                        Mileage = "50",
                        IsTransit = false,
                        VehiclesCompanyId = 1
                    }
                    );
                applicationContext.SaveChanges();
            }

            if (!applicationContext.Orders.Any()){
                applicationContext.Orders.AddRange(
                    new Order
                    {
                        Route = "route1",
                        IsComplite = true,
                        Date = new DateTime(2021, 7, 20),
                        VehicleId = 1
                    },
                    new Order
                    {
                        Route = "route2",
                        IsComplite = true,
                        Date = new DateTime(2021, 7, 21),
                        VehicleId = 1
                    },
                    new Order
                    {
                        Route = "route3",
                        IsComplite = false,
                        Date = new DateTime(2021, 7, 22),
                        VehicleId = 2
                    },
                    new Order
                    {
                        Route = "route4",
                        IsComplite = false,
                        Date = new DateTime(2021, 7, 22),
                        VehicleId = 2
                    },
                    new Order
                    {
                        Route = "route5",
                        IsComplite = true,
                        Date = new DateTime(2021, 7, 21),
                        VehicleId = 2
                    },
                    new Order
                    {
                        Route = "route6",
                        IsComplite = false,
                        Date = new DateTime(2021, 7, 22),
                        VehicleId = 2
                    }
                    );
                applicationContext.SaveChanges();
            }
        }
    }
}
