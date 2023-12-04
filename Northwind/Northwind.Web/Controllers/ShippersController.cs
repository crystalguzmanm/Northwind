using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Amqp.Sasl;
using Newtonsoft.Json;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Shippers;
using Northwind.Web.Models.Response;

namespace Northwind.Web.Controllers
{
    public class ShippersController : Controller
    {
        private readonly IShippersService shippersService;
        private readonly HttpClientHandler clientHandler;
        private readonly string baseApiUrl;

        public ShippersController(IShippersService shippersService)
        {
            this.shippersService = shippersService;
            // objeto  clientHandler base  para reutilizar en los  endpoints de la capa de presentacion //
            this.clientHandler = new HttpClientHandler();
            //Url  base para reutilizar en los  endpoints de la capa de presentacion //
            this.baseApiUrl = "http://localhost:5069/api/Shippers";
        }

        private HttpClient CreateHttpClient()
        {
            return new HttpClient(this.clientHandler);
        }


        // GET: ShipepersController1
        public ActionResult Index()
        {  
            ShippersListResponse shippersList = new ShippersListResponse();
            //reutilizacion de la url base para el endpoints Index //
            using (var client = CreateHttpClient())
            {   //reutilizacion de la clientHandler base para el  endpoints Index //
                using (var response = client.GetAsync($"{baseApiUrl}").Result)
                { 
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponde =  response.Content.ReadAsStringAsync().Result;

                        shippersList =  JsonConvert.DeserializeObject<ShippersListResponse>(apiResponde);
                        
                        if (!shippersList.success)
                        {
                            ViewBag.Message = shippersList.message;
                            return View();
                        }
                    }
                    else
                    {
                        shippersList.message = "Error conectandose al api.";
                        shippersList.success = false;
                        ViewBag.Message = shippersList.message;
                        return View();
                    }

                }

            }

            return View(shippersList.data);
        }

        // GET: ShipepersController1/Details/5
        public ActionResult Details(int id)
        {
             
            ShippersDetailResponse shippersDetailResponse = new ShippersDetailResponse();
            //reutilizacion de la clientHandler base para  el endpoints Details //
            using (var client = new HttpClient(this.clientHandler))
            {
                {      // reutilizacion de la url base para el endpoints Details   //
                var url = $"{baseApiUrl}/GetShippers";
                {
                    using (var response = client.GetAsync(url).Result)
                    { if(response.IsSuccessStatusCode)
                        { string apiResponse =  response.Content.ReadAsStringAsync().Result;

                            shippersDetailResponse = JsonConvert.DeserializeObject<ShippersDetailResponse>(apiResponse);

                            if (!shippersDetailResponse.success)
                            {
                                ViewBag.Message =  shippersDetailResponse.message;  
                            }  
                        }

                    }
               

                }
                return View(shippersDetailResponse.data);
            }
        }

        // POST: ShipepersController1/Create
        [HttpPost]

            public ActionResult Create(ShippersDtoAdd shippersDtoAdd)
            {
            BaseReponse baseResponse = new BaseReponse();

            try
            {    //reutilizacion de la clientHandler base para el  endpoints Create //
                using (var client = CreateHttpClient())
                {
                    // Reutilización de la url base para el endpoint Create
                    var url = $"{baseApiUrl}/SaveShippers";

                    shippersDtoAdd.ChangeDate = DateTime.Now;
                    shippersDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(shippersDtoAdd), System.Text.Encoding.UTF8, "application/json");

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
            ShippersDetailResponse shippersDetailResponse = new ShippersDetailResponse();
            //reutilizacion de la clientHandler base para  el endpoints Edit //
            using (var client = CreateHttpClient())
            { // reutilizacion de la url base el endpoints Edit  //
                var url = $"{baseApiUrl}/GetShippers?id={id}";
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

        // POST: ShipepersController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ShippersDtoUpdate shippersDtoUpdate)
        {
             BaseReponse baseReponse = new BaseReponse();   
            try
            {


                //reutilizacion de la clientHandler base para el endpoints Edit //
                using (var client = CreateHttpClient())
                {   // reutilizacion de la url base el endpoints Edit //
                    var url = $"{baseApiUrl}/UpdateShippers";
                    shippersDtoUpdate.ChangeDate = DateTime.Now;
                    shippersDtoUpdate.ChangeUser = 1;

                     StringContent content = new StringContent(JsonConvert.SerializeObject(shippersDtoUpdate),System.Text.Encoding.UTF8,"/application/json");
                        
                        using (var response = client.PostAsync(url,content).Result)
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
