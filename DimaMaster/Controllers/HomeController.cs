using DimaMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace DimaMaster.Controllers
{
    public class TopClientsView
    {
        public string Lfm { get; set; }
        public decimal TotalSum { get; set; }

    }

    public class TopServicesView
    {
        public string ServiceName { get; set; }
        public decimal TotalSum { get; set; }

    }

    public class MostOrderedServices
    {
        public string ServiceName { get; set; }
        public int Count { get; set; }
    }
    public class BestEmployee
    {
        public string Lfm { get; set; }
        public int Count { get; set; }
    }

    public class MostProfitableEmployee
    {
        public string Lfm { get; set; }
        public decimal TotalSum { get; set; }
    }
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            var topCarServices = (from order in db.Orders.AsNoTracking()
                                  group order by order.Service
                          ).Select(x => new TopClientsView
                          {
                              Lfm = x.Key.Name,
                              TotalSum = x.Sum(w => w.Service.Cost)
                          }).OrderByDescending(x => x.TotalSum);

            ViewBag.topCarServices = JsonConvert.SerializeObject(topCarServices);

            return View();
        }
        public ActionResult Reports()
        {

            return View();
        }
        public ActionResult TopClients()
        {
            var request = (from order in db.Orders.AsNoTracking()
                           group order by order.Client
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