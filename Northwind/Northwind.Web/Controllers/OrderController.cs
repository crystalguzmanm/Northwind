using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Orders;
using Northwind.Web.Models.Response;

namespace Northwind.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersServices ordersServices;
        HttpClientHandler clientHandler = new HttpClientHandler();
        private object baseApiUrl;

        public OrderController(IOrdersServices ordersServices)
        {
            this.ordersServices = ordersServices;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            OrdersListResponse ordersList = new OrdersListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5069/api/Orders").Result)
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        ordersList = JsonConvert.DeserializeObject<OrdersListResponse>(apiResponse);
                    }
            }

            return View(ordersList.data);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {

            OrdersDetailResponse ordersDetailResponse = new OrdersDetailResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5069/api/Orders/Getorders?{id}";
                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        ordersDetailResponse = JsonConvert.DeserializeObject<OrdersDetailResponse>(apiResponse);
                    }

                }
            }

            return View(ordersDetailResponse.data);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdersDtoAdd ordersDtoAdd)
        {
            ServicesResult result = new ServicesResult();
            try
            {
                result = this.ordersServices.Save(ordersDtoAdd);
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {

            OrdersDetailResponse ordersDetailResponse = new OrdersDetailResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5069/api/Orders/Getorders?{id}";
                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        ordersDetailResponse = JsonConvert.DeserializeObject<OrdersDetailResponse>(apiResponse);
                    }

                }
            }

            return View(ordersDetailResponse.data);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdersDtoUpdate ordersDtoUpdate)
        {
            BaseResponse baseReponse = new BaseResponse();
            try
            {


                
                using (var client = new HttpClient(this.clientHandler))
                {   
                    var url = $"{baseApiUrl}/UpdateOrders";
                    ordersDtoUpdate.ModifyDate = DateTime.Now;
                    ordersDtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(ordersDtoUpdate), System.Text.Encoding.UTF8, "/application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseReponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);
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

