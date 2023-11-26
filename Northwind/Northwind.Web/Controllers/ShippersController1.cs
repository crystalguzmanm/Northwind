using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Contracts;

namespace Northwind.Web.Controllers
{
    public class ShippersController1 : Controller
    {
        private readonly IShippersService shippersService;

        public ShippersController1(IShippersService shippersService)
        {
            this.shippersService = shippersService;
        }

        // GET: ShipepersController1
        public ActionResult Index()
        {
            var result =  this.shippersService.GetAll();   
            if(!result.Success)
            {
                ViewBag.Message =  result.Message;
                return View();

            }
            return View(result.Data);

        }

        // GET: ShipepersController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShipepersController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipepersController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShipepersController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShipepersController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShipepersController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShipepersController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
