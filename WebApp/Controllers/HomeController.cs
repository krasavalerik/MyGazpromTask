using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View(_unitOfWork.VehiclesCompanys.GetAll());
        }

        public IActionResult OrdersIndex(int id){
            ViewBag.CompanyId = id;
            ViewBag.CompanyName = _unitOfWork.VehiclesCompanys.Get(id).Name;

            return View(_unitOfWork.VehiclesCompanys.GetCompanyOrders(id));
        }

        public IActionResult VehiclesIndex(int? id){

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
            var order = _unitOfWork.Orders.Get(id);
            List<Vehicle> vehiclesLits = _unitOfWork.Vehicles.Find(c => c.VehiclesCompanyId == company).ToList();
            ViewBag.Vehicles = vehiclesLits;

            return View(order);
        }

        [HttpPost]
        public IActionResult EditIndex(Order order){
            order.Date = DateTime.Now;

            _unitOfWork.Orders.Edit(order);
            _unitOfWork.Complite();

            return RedirectToAction("Index");
        }

        public IActionResult AddIndex(int companyId){
            ViewBag.Vehicles = _unitOfWork.Vehicles.Find(c => c.VehiclesCompanyId == companyId).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddIndex(Order order){
            order.Date = DateTime.Now;

            _unitOfWork.Orders.Add(order);
            _unitOfWork.Complite();

            return RedirectToAction("Index");
        }

        public IActionResult AddVehicleIndex(){
            ViewBag.Companys = _unitOfWork.VehiclesCompanys.GetAll().ToList();

            return View();
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
