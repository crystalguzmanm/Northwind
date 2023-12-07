using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Northwind.Application.Contracts;
using Northwind.Application.DTOs.Customers;
using Northwind.Web.Models.Responses;

namespace Northwind.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomersService customersService;
        private readonly HttpClientHandler clientHandler;
        private readonly string baseApiUrl;

        public CustomerController(ICustomersService customersService)
        {
            this.customersService = customersService;
            this.clientHandler = new HttpClientHandler();
            this.baseApiUrl = "http://localhost:5069/api/Shippers";
        }

        private HttpClient CreateHttpClient()
        {
            return new HttpClient(this.clientHandler);
        }


        // GET: CustomerController
        public ActionResult Index()
        {
            CustomerListResponse customerList = new CustomerListResponse();


            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync($"{baseApiUrl}").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        customerList = JsonConvert.DeserializeObject<CustomerListResponse>(apiResponse);

                        if (!customerList.success)
                        {
                            ViewBag.Message = customerList.message;
                            return View();
                        }
                    }
                    else
                    {
                        customerList.message = "Error al conectarse a la API.";
                        customerList.success = false;
                        ViewBag.Message = customerList.message;
                        return View();
                    }
                }

                return View(customerList.data);
            }

            // GET: CustomerController/Details/5
            public ActionResult Details(int id)
            {
                CustomerDetailResponse customerDetailResponse = new CustomerDetailResponse();


                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"{baseApiUrl}/getCustomers";

                    using (var response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            customerDetailResponse = JsonConvert.DeserializeObject<customerDetailResponse>(apiResponse);

                            if (!customerDetailResponse.success)
                                ViewBag.Message = customerDetailResponse.message;


                        }
                    }
                }


                return View(customerDetailResponse.data);
            }

            // GET: CustomerController/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: CustomerController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(IFormCollection collection)
            {
                BaseResponse baseResponse = new BaseResponse();

                try
                {

                    using (var client = new HttpClient(this.clientHandler))
                    {

                        var url = $"{baseApiUrl}/SaveCustomers";

                        CustomersDtoAdd.ChangeDate = DateTime.Now;
                        CustomersDtoAdd.ChangeUser = 1;

                        StringContent content = new StringContent(JsonConvert.SerializeObject(CustomersDtoAdd), System.Text.Encoding.UTF8, "application/json");

                        using (var response = client.PostAsync(url, content).Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = response.Content.ReadAsStringAsync().Result;
                                baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                                if (!baseResponse.success)
                                {
                                    ViewBag.Message = baseResponse.message;
                                    return View();
                                }

                            }

                            else
                            {
                                baseResponse.message = "Error al conectarse a la API.";
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

            // GET: CustomerController/Edit/5
            public ActionResult Edit(int id)
            {
                CustomerDetailResponse customerDetailResponse = new CustomerDetailResponse();


                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"{baseApiUrl}/GetCustomer?id={id}";

                    using (var response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            customerDetailResponse = JsonConvert.DeserializeObject<customerDetailResponse>(apiResponse);

                        }
                    }
                }


                return View(customerDetailResponse.data);
            }

            // POST: CustomerController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(CustomersDtoUpdate dtoUpdate)
            {
                BaseResponse baseResponse = new BaseResponse();

                try
                {

                    using (var client = new HttpClient(this.clientHandler))
                    {

                        var url = $"{baseApiUrl}/UpdateCustomers";

                        CustomersDtoUpdate.ChangeDate = DateTime.Now;
                        CustomersDtoUpdate.ChangeUser = 1;

                        StringContent content = new StringContent(JsonConvert.SerializeObject(CustomersDtoUpdate), System.Text.Encoding.UTF8, "application/json");

                        using (var response = client.PostAsync(url, content).Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = response.Content.ReadAsStringAsync().Result;

                                baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                                if (!baseResponse.success)
                                {
                                    ViewBag.Message = baseResponse.message;
                                    return View();
                                }

                            }
                            else
                            {
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
        }
    }
}
