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
        private readonly HttpClientHandler clientHandler;
        private readonly string baseApiUrl;

        public SuppliersController(ISuppliersService suppliersService)
        {
            this.suppliersService = suppliersService;
            // objeto  clientHandler base  para reutilizar en los  endpoints de la capa de presentacion //
            this.clientHandler = new HttpClientHandler();
            //Url  base para reutilizar en los  endpoints de la capa de presentacion //
            this.baseApiUrl = "http://localhost:5069/api/Suppliers";
        }

        private HttpClient CreateHttpClient()
        {
            return new HttpClient(this.clientHandler);
        }


        // GET: ShipepersController1
        public ActionResult Index()
        {
            SuppliersListResponse suppliersList = new SuppliersListResponse();
            //reutilizacion de la url base para el endpoints Index //
            using (var client = CreateHttpClient())
            {   //reutilizacion de la clientHandler base para el  endpoints Index //
                using (var response = client.GetAsync($"{baseApiUrl}").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponde = response.Content.ReadAsStringAsync().Result;

                        suppliersList = JsonConvert.DeserializeObject<SuppliersListResponse >(apiResponde);

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

        // GET: ShipepersController1/Details/5
        public ActionResult Details(int id)
        {

            SuppliersDetailResponse suppliersDetailResponse = new SuppliersDetailResponse();
            //reutilizacion de la clientHandler base para  el endpoints Details //
            using (var client = CreateHttpClient())
            {      // reutilizacion de la url base para el endpoints Details   //
                var url = $"{baseApiUrl}/GetShippers";
                {
                    using (var response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            suppliersDetailResponse = JsonConvert.DeserializeObject<ShippersDetailResponse>(apiResponse);

                            if (!suppliersDetailResponse.success)
                            {
                                ViewBag.Message = suppliersDetailResponse.message;
                            }
                        }

                    }


                }
                return View(suppliersDetailResponse.data);
            }
        }

        // POST: ShipepersController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuppliersDtoAdd suppliersDtoAdd)
        {
            BaseReponse baseResponse = new BaseReponse();

            try
            {    //reutilizacion de la clientHandler base para el  endpoints Create //
                using (var client = CreateHttpClient())
                {
                    // Reutilización de la url base para el endpoint Create
                    var url = $"{baseApiUrl}/SaveShippers";

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
                            baseResponse.message = "Error conectándose al api.";
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
            SuppliersDetailResponse suppliersDetailResponse = new SuppliersDetailResponse();
            //reutilizacion de la clientHandler base para  el endpoints Edit //
            using (var client = CreateHttpClient())
            { // reutilizacion de la url base el endpoints Edit  //
                var url = $"{baseApiUrl}/GetSuppliers?id={id}";
                {
                    using (var response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            suppliersDetailResponse = JsonConvert.DeserializeObject<SuppliersDtoUpdate>(apiResponse);
                        }

                    }

                }
                return View(suppliersDetailResponse.data);
            }
        }

        // POST: ShipepersController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuppliersDtoUpdate suppliersDtoUpdate)
        {
            BaseReponse baseReponse = new BaseReponse();
            try
            {


                //reutilizacion de la clientHandler base para el endpoints Edit //
                using (var client = CreateHttpClient())
                {   // reutilizacion de la url base el endpoints Edit //
                    var url = $"{baseApiUrl}/UpdateSuppliers";
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
