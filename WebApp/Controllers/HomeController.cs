using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using ModelsClassLibrary.UnitOfWork;
using ModelsClassLibrary.Entitys;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        private List<VehiclesCompany> _vehiclesCompanyList;
        private List<Vehicle> _vehiclesList;

        public HomeController(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(){
            ViewBag.Title = "Транспортные компании";
            var companys = _unitOfWork.VehiclesCompanys.GetAll();

            return View(companys);
        }

        public IActionResult OrdersIndex(int id){
            ViewBag.Title = "Заказы";
            ViewBag.CompanyId = id;
            ViewBag.CompanyName = _unitOfWork.VehiclesCompanys.Get(id).Name;
            var companyOrders = _unitOfWork.VehiclesCompanys.GetCompanyOrders(id);

            return View(companyOrders);
        }

        public IActionResult VehiclesIndex(int? id){

            ViewBag.Title = "Автопарк";
            _vehiclesCompanyList = _unitOfWork.VehiclesCompanys.GetAll().ToList();
            _vehiclesCompanyList.Insert(0, new VehiclesCompany { Id = 0, Name = "all" });
            _vehiclesList = _unitOfWork.Vehicles.GetAll().ToList();

            CompanysWithVehicles cwv = new CompanysWithVehicles{
                VehiclesCompanies = _vehiclesCompanyList,
                Vehicles = _vehiclesList
            };

            if (id != 0 && id > 0)
                cwv.Vehicles = _vehiclesList.Where(v => v.VehiclesCompany.Id == id);

            return View(cwv);
        }

        public IActionResult EditIndex(int id, int company){
            ViewBag.ComanyId = company;
            var editModel = new EditModel();
            editModel.Order = _unitOfWork.Orders.Get(id);
            editModel.Vehicles = _unitOfWork.Vehicles.Find(c => c.VehiclesCompanyId == company).ToList();

            return View(editModel);
        }

        [HttpPost]
        public IActionResult EditIndex(Order order){
            order.Date = DateTime.Now;

            _unitOfWork.Orders.Edit(order);
            _unitOfWork.Complite();

            return RedirectToAction("Index");
        }

        public IActionResult AddIndex(int companyId){
            ViewBag.Title = "Новый заказ";
            var vehicles = _unitOfWork.Vehicles.Find(c => c.VehiclesCompanyId == companyId).ToList();

            return View(vehicles);
        }

        [HttpPost]
        public IActionResult AddIndex(Order order){
            order.Date = DateTime.Now;

            _unitOfWork.Orders.Add(order);
            _unitOfWork.Complite();

            return RedirectToAction("Index");
        }

        public IActionResult AddVehicleIndex(){
            ViewBag.Title = "Новый автомобиль";
            var companys = _unitOfWork.VehiclesCompanys.GetAll().ToList();

            return View(companys);
        }

        [HttpPost]
        public IActionResult AddVehicleIndex(Vehicle vehicle){
            _unitOfWork.Vehicles.Add(vehicle);
            _unitOfWork.Complite();

            return RedirectToAction("VehiclesIndex");
        }

        public IActionResult Delete(int id){
            var oreder = _unitOfWork.Orders.Get(id);

            _unitOfWork.Orders.Delete(oreder);
            _unitOfWork.Complite();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteVehicle(int id){
            var vehicle = _unitOfWork.Vehicles.Get(id);

            _unitOfWork.Vehicles.Delete(vehicle);
            _unitOfWork.Complite();

            return RedirectToAction("VehiclesIndex");
        }
    }
}
