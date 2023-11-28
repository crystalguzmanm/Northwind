using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Shippers;
using Northwind.Application.Dtos.Suppliers;
using Northwind.Web.Models.Response;

namespace Northwind.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliersService suppliersService;
        HttpClientHandler clientHandler = new HttpClientHandler();
        public SuppliersController(ISuppliersService suppliersService)
        {
            this.suppliersService = suppliersService;
        }

        // GET: SuppliersController
        public ActionResult Index()
        {
            SuppliersListResponse suppliersList = new SuppliersListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5069/api/Suppliers/Getsuppliers").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponde = response.Content.ReadAsStringAsync().Result;

                        suppliersList = JsonConvert.DeserializeObject<SuppliersListResponse>(apiResponde);

                        if (!suppliersList.success)
                        {
                            ViewBag.Message = suppliersList.message;
                            return View();
                        }
                    }
                    else
                    {
                        suppliersList.message = "Error conectandose al api.";
                        suppliersList.success = false;
                        ViewBag.Message = suppliersList.message;
                        return View();
                    }

                }

            }

            return View(suppliersList.data);
        }

        // GET: SuppliersController/Details/5
        public ActionResult Details(int id)
        {

            SuppliersDetailReponse suppliersDetailReponse = new SuppliersDetailReponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5069/api/Suppliers/={id}";
                {
                    using (var response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            suppliersDetailReponse = JsonConvert.DeserializeObject<SuppliersDetailReponse>(apiResponse);

                            if (!suppliersDetailReponse.success)
                            {
                                ViewBag.Message = suppliersDetailReponse.message;
                            }
                        }

                    }

                }
                return View(suppliersDetailReponse.data);
            }
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
            BaseReponse baseResponse = new BaseReponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5069/api/Suppliers/SaveSuppliers";

                    suppliersDtoAdd.ChangeDate = DateTime.Now;
                    suppliersDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(suppliersDtoAdd), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseResponse = JsonConvert.DeserializeObject<BaseReponse>(apiResponse);

                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }

                        }
                        else
                        {
                            baseResponse.message = "Error conectandose al api.";
                            baseResponse.success = false;
                            ViewBag.Message = baseResponse.message;
                            return View();
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }

        // GET: ShipepersController1/Edit/5
        public ActionResult Edit(int id)
        {
            ShippersDetailResponse shippersDetailResponse = new ShippersDetailResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5069/api/Shippers/Getshippers?Id={id}";
                {
                    using (var response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            shippersDetailResponse = JsonConvert.DeserializeObject<ShippersDetailResponse>(apiResponse);
                        }

                    }

                }
                return View(shippersDetailResponse.data);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuppliersDtoUpdate suppliersDtoUpdate)
        {
            BaseReponse baseReponse = new BaseReponse();
            try
            {



                using (var client = new HttpClient(this.clientHandler))
                {
                    var url = $"http://localhost:5069/api/Suppliers/Updatesuppliers";
                     suppliersDtoUpdate.ChangeDate = DateTime.Now;
                    suppliersDtoUpdate.ChangeUser = 1;
                    StringContent content = new StringContent(JsonConvert.SerializeObject(suppliersDtoUpdate), System.Text.Encoding.UTF8, "/application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseReponse = JsonConvert.DeserializeObject<BaseReponse>(apiResponse);
                            if (!baseReponse.success)
                            {
                                ViewBag.message = baseReponse.message;
                                return View();
                            }

                        }
                        else
                        {
                            ViewBag.Message = baseReponse.message;
                            return View();
                        }

                    }


                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = baseReponse.message;
                return View();
            }

        }

    }

    }
