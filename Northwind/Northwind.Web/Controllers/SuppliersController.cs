using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Shippers;
using Northwind.Application.Dtos.Suppliers;

namespace Northwind.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliersService suppliersService;

        public SuppliersController(ISuppliersService suppliersService)
        {
            this.suppliersService = suppliersService;
        }

        // GET: SuppliersController
        public ActionResult Index()
        {
            var result = this.suppliersService.GetAll();
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();

            }
            return View(result.Data);

        }

        // GET: SuppliersController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.suppliersService.GetById(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();

            }
   

            return View(result.Data);
        }

        // GET: SuppliersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuppliersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuppliersDtoAdd suppliersDtoAdd)
        {

            ServicesResult result = new ServicesResult();
            try
            {
                result = this.suppliersService.Save(suppliersDtoAdd);
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

        // GET: SuppliersController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.suppliersService.GetById(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();

            }


            return View(result.Data);
        }

        // POST: SuppliersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuppliersDtoUpdate suppliersDtoUpdate)
        {

            ServicesResult result = new ServicesResult();
            try
            {
                result = this.suppliersService.Update(suppliersDtoUpdate);
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

        // GET: SuppliersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuppliersController/Delete/5
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
