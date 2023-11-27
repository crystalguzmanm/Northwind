using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Shippers;

namespace Northwind.Web.Controllers
{
    public class ShippersController : Controller
    {
        private readonly IShippersService shippersService;

        public ShippersController(IShippersService shippersService)
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

            var result = this.shippersService.GetById(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();

            }
            return View(result.Data);

        }

        // GET: ShipepersController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipepersController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShippersDtoAdd shippersDtoAdd)
        {
            ServicesResult result = new ServicesResult();
            try
            {
                 result = this.shippersService.Save(shippersDtoAdd);
                if (!result.Success)
                {   ViewBag.Message = result.Message;   
                    return View();

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }

        // GET: ShipepersController1/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.shippersService.GetById(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();

            }

            return View(result.Data);
        }

        // POST: ShipepersController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ShippersDtoUpdate shippersDtoUpdate)
        {
            ServicesResult result  = new ServicesResult();
            try
            {
                result = this.shippersService.Update(shippersDtoUpdate);
                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
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
