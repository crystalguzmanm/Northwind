﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Amqp.Sasl;
using Newtonsoft.Json;
using Northwind.Application.Contracts;
using Northwind.Application.Core;
using Northwind.Application.Dtos.Products;
using Northwind.Web.Models.Response;

namespace Northwind.Web.Controllers
<<<<<<< HEAD
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        HttpClientHandler clientHandler = new HttpClientHandler();
        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        // GET: ProductsController1
        public ActionResult Index()
        {
            ProductsListResponse productsList = new ProductsListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5286/api/Products").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponde = response.Content.ReadAsStringAsync().Result;

                        productsList.data = JsonConvert.DeserializeObject<List<ProductsViewResult>>(apiResponde);
                        if (productsList.data != null)
                        {
                            productsList.success = true;
                        }
                        if (!productsList.success)
                        {
                            ViewBag.Message = productsList.message;
                            return View();
                        }
                    }
                    else
                    {
                        productsList.message = "Error conectandose al api.";
                        productsList.success = false;
                        ViewBag.Message = productsList.message;
                        return View();
=======
    {
        public class ProductsController : Controller
        {
            private readonly IProductsService productsService;

            HttpClientHandler clientHandler = new HttpClientHandler();
            public ProductsController(IProductsService productsService)
            {
                this.productsService = productsService;
            }

            // GET: ProductsController1
            public ActionResult Index()
            {
                ProductsListResponse productsList = new ProductsListResponse();

                using (var client = new HttpClient(this.clientHandler))
                {
                    using (var response = client.GetAsync("http://localhost:5069/api/Shippers").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponde = response.Content.ReadAsStringAsync().Result;

                            productsList = JsonConvert.DeserializeObject<ProductsListResponse>(apiResponde);

                            if (!productsList.success)
                            {
                                ViewBag.Message = productsList.message;
                                return View();
                            }
                        }
                        else
                        {
                            productsList.message = "Error conectandose al api.";
                            productsList.success = false;
                            ViewBag.Message = productsList.message;
                            return View();
                        }

>>>>>>> 27810b607528a82277bd7f871bd8969b136687a7
                    }

                }

<<<<<<< HEAD
            }

            return View(productsList.data);
        }

        // GET: ProductsController1/Details/5
        public ActionResult Details(int ProductID)
        {

            ProductsDetailResponse productsDetailResponse = new ProductsDetailResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5286/api/Products/Getproducts?Id={ProductID}";
                {
                    using (var response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            productsDetailResponse.data = JsonConvert.DeserializeObject<ProductsViewResult>(apiResponse);

                            if (!productsDetailResponse.success)
                            {
                                ViewBag.Message = productsDetailResponse.message;
                            }
                        }

                    }

                }
                return View(productsDetailResponse.data);
            }
        }

        // GET: ProductsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductsDtoAdd productsDtoAdd)
        {
            BaseReponse baseResponse = new BaseReponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5286/api/Products/SaveProducts";

                    productsDtoAdd.CreationDate = DateTime.Now;
                    productsDtoAdd.CreationUser = 1;

                    using (var response = client.PostAsJsonAsync(url, productsDtoAdd).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
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

        // GET: ProductsController1/Edit/5
        public ActionResult Edit(int ProductID)
        {
            ProductsDetailResponse productsDetailResponse = new ProductsDetailResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5286/api/Products/Getproducts?Id={ProductID}";
                {
                    using (var response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            productsDetailResponse = JsonConvert.DeserializeObject<ProductsDetailResponse>(apiResponse);
                        }

                    }

                }
                return View(productsDetailResponse.data);
            }
        }

        // POST: ProductsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductsDtoUpdate productsDtoUpdate)
        {
            BaseReponse baseReponse = new BaseReponse();
            try
            {



                using (var client = new HttpClient(this.clientHandler))
                {
                    var url = $"http://localhost:5286/api/Products/Updateproducts";
                    productsDtoUpdate.CreationDate = DateTime.Now;
                    productsDtoUpdate.CreationUser = 2;

                    using (var response = client.PutAsJsonAsync(url, productsDtoUpdate).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
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
=======
                return View(productsList.data);
            }

            // GET: ProductsController1/Details/5
            public ActionResult Details(int id)
            {

                ProductsDetailResponse productsDetailResponse = new ProductsDetailResponse();

                using (var client = new HttpClient(this.clientHandler))
                {
                    var url = $"http://localhost:5069/api/Shippers/Getshippers?Id={id}";
                    {
                        using (var response = client.GetAsync(url).Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = response.Content.ReadAsStringAsync().Result;

                                productsDetailResponse = JsonConvert.DeserializeObject<ProductsDetailResponse>(apiResponse);

                                if (!productsDetailResponse.success)
                                {
                                    ViewBag.Message = productsDetailResponse.message;
                                }
                            }

                        }

                    }
                    return View(productsDetailResponse.data);
                }
            }

            // GET: ProductsController1/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: ProductsController1/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(ProductsDtoAdd productsDtoAdd)
            {
                BaseResponse baseResponse = new BaseResponse();

                try
                {

                    using (var client = new HttpClient(this.clientHandler))
                    {

                        var url = $"http://localhost:5069/api/Shippers/SaveShippers";

                        productsDtoAdd.CreationDate = DateTime.Now;
                        productsDtoAdd.CreationUser = 65;

                        StringContent content = new StringContent(JsonConvert.SerializeObject(productsDtoAdd), System.Text.Encoding.UTF8, "application/json");

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

            // GET: ProductsController1/Edit/5
            public ActionResult Edit(int id)
            {
                ProductsDetailResponse productsDetailResponse = new ProductsDetailResponse();

                using (var client = new HttpClient(this.clientHandler))
                {
                    var url = $"http://localhost:5069/api/Shippers/Getshippers?Id={id}";
                    {
                        using (var response = client.GetAsync(url).Result)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string apiResponse = response.Content.ReadAsStringAsync().Result;

                                productsDetailResponse = JsonConvert.DeserializeObject<ProductsDetailResponse>(apiResponse);
                            }

                        }

                    }
                    return View(productsDetailResponse.data);
                }
            }

            // POST: ProductsController1/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(ProductsDtoUpdate productsDtoUpdate)
            {
                BaseResponse baseReponse = new BaseResponse();
                try
                {



                    using (var client = new HttpClient(this.clientHandler))
                    {
                        var url = $"http://localhost:5069/api/Shippers/Updateshippers";
                        productsDtoUpdate.CreationDate = DateTime.Now;
                        productsDtoUpdate.CreationUser = 65;
                        StringContent content = new StringContent(JsonConvert.SerializeObject(productsDtoUpdate), System.Text.Encoding.UTF8, "/application/json");

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
>>>>>>> 27810b607528a82277bd7f871bd8969b136687a7
