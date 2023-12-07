using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Web.Controllers
{
    public class OrdersWithHttpClientController : Controller
    {
        // GET: OrdersWithHttpClientController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrdersWithHttpClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdersWithHttpClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersWithHttpClientController/Create
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

        // GET: OrdersWithHttpClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdersWithHttpClientController/Edit/5
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

        // GET: OrdersWithHttpClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdersWithHttpClientController/Delete/5
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
