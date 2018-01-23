using DimaMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace DimaMaster.Controllers
{
    public class NameModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult GenerateClients()
        {
            var r = new Random();
            var json1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NameModel>>(System.IO.File.ReadAllText(Server.MapPath("~/russian_names.json")));
            var json12 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NameModel>>(System.IO.File.ReadAllText(Server.MapPath("~/russian_surnames.json")));
            var carServieces = db.CarServices.ToList();
            for (int i = 0; i < 100; i++)
            {
                var carService = carServieces[r.Next(0, carServieces.Count - 1)];
                var e = new Employee()
                {
                    LFM = json1[i].Name + " " + json12[i].Surname,
                    PhoneNumber = r.Next(100000, 10000000).ToString(),
                    Age = r.Next(15, 55),
                    CarService = carService,
                };
                db.Employees.Add(e);
            }
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult RandomOrders()
        {
            var r = new Random();
            var clients = db.Clients.ToList();
            var empls = db.Employees.ToList();
            var services = db.Services.ToList();
            for (int i = 0; i < 1000; i++)
            {
                var order = new Order();
                var index = r.Next(1, clients.Count - 1);
                order.Car = clients[index].Cars.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                if (order.Car == null) continue;
                order.Employee = empls[r.Next(0, empls.Count - 1)];
                order.DateCreate = DateTime.Now;
                order.Service = services[r.Next(0, services.Count - 1)];
                order.Vendor = "Vendor";
                db.Orders.Add(order);
            }
            db.SaveChanges();
            return RedirectToAction("Home");
        }
        public ActionResult Index()
        {
            var topCarServices = (from order in db.Orders.AsNoTracking()
                                  group order by order.Service
                          ).Select(x => new TopClientsView
                          {
                              Lfm = x.Key.Name,
                              TotalSum = x.Sum(w => w.Service.Cost)
                          }).OrderByDescending(x => x.TotalSum).Take(20);

            ViewBag.topCarServices = JsonConvert.SerializeObject(topCarServices);

            return View("Index");
        }
        public ActionResult Reports()
        {

            return View();
        }
        public ActionResult TopClients()
        {
            var request = (from order in db.Orders.AsNoTracking()
                           group order by order.Car.Client
                           ).Select(x => new TopClientsView
                           {
                               Lfm = x.Key.LFM,
                               TotalSum = x.Sum(w => w.Service.Cost)
                           }).OrderByDescending(x => x.TotalSum);
            return View(request.ToList());
        }

        public ActionResult TopProfitServices()
        {
            var request = (from order in db.Orders.AsNoTracking()
                           group order by order.Service
                          ).Select(x => new TopClientsView
                          {
                              Lfm = x.Key.Name,
                              TotalSum = x.Sum(w => w.Service.Cost)
                          }).OrderByDescending(x => x.TotalSum);
            return View(request.ToList());
        }
        public ActionResult TopServices()
        {
            var request = (from order in db.Orders.AsNoTracking()
                           group order by order.Service
                          ).Select(x => new MostOrderedServices
                          {
                              ServiceName = x.Key.Name,
                              Count = x.Count()
                          }).OrderByDescending(x => x.Count);
            return View(request.ToList());
        }
        public ActionResult TopEmployee()
        {
            var request = (from order in db.Orders.AsNoTracking()
                           group order by order.Employee
                          ).Select(x => new BestEmployee
                          {
                              Lfm = x.Key.LFM,
                              Count = x.Count()
                          }).OrderByDescending(x => x.Count);
            return View(request.ToList());
        }

        public ActionResult MostProfitableEmployee()
        {
            var request = (from order in db.Orders.AsNoTracking()
                           group order by order.Employee
                          ).Select(x => new MostProfitableEmployee
                          {
                              Lfm = x.Key.LFM,
                              TotalSum = x.Sum(w => w.Service.Cost)
                          }).OrderByDescending(x => x.TotalSum);
            return View(request.ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}