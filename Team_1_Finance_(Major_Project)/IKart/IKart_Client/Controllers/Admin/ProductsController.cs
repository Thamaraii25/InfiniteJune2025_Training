﻿using System;

using System.Collections.Generic;

using System.Linq;

using System.Web.Mvc;

using System.Net.Http;

using IKart_Shared.DTOs.Admin;

using Newtonsoft.Json;

using System.Text;

using System.IO;

using System.Web;

namespace IKart_Client.Controllers

{

    public class ProductsController : Controller

    {

        string apiUrl = "https://localhost:44365/api/products";

        string stocksApiUrl = "https://localhost:44365/api/stocks";


        public ActionResult Index()

        {

            List<ProductDto>

    products = new List<ProductDto>

        ();

            using (var handler = new HttpClientHandler())

            {

                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))

                {

                    var res = client.GetAsync(apiUrl).Result;

                    if (res.IsSuccessStatusCode)

                    {

                        var data = res.Content.ReadAsStringAsync().Result;

                        products = JsonConvert.DeserializeObject<List<ProductDto>>(data);

                    }

                }

            }

            return View(products);

        }


        public ActionResult Create()

        {

            PopulateStocksDropdowns();

            return View();

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Create(ProductDto product, HttpPostedFileBase ProductImageFile)

        {

            if (ModelState.IsValid)

            {

                if (ProductImageFile != null && ProductImageFile.ContentLength > 0)

                {

                    string fileName = Path.GetFileName(ProductImageFile.FileName);
                    string folderPath = Server.MapPath("~/Content/ProductImages/");

                    if (!Directory.Exists(folderPath))

                    {

                        Directory.CreateDirectory(folderPath);

                    }

                    string filePath = Path.Combine(folderPath, fileName);

                    ProductImageFile.SaveAs(filePath);


                    product.ProductImage = fileName;

                }

                // ✅ Allow self-signed SSL certs (development only!)

                System.Net.ServicePointManager.ServerCertificateValidationCallback =

                    (sender, cert, chain, sslPolicyErrors) => true;

                // ✅ Call API

                using (var client = new HttpClient())

                {

                    client.BaseAddress = new Uri(apiUrl);

                    var json = JsonConvert.SerializeObject(product);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = client.PostAsync("", content).Result;

                    if (response.IsSuccessStatusCode)

                    {

                        return RedirectToAction("Index");

                    }

                    else

                    {

                        ModelState.AddModelError("", "Error: " + response.ReasonPhrase);

                    }

                }

            }

            return View(product);

        }


        public ActionResult Edit(int id)

        {

            ProductDto dto = null;

            using (var handler = new HttpClientHandler())

            {

                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))

                {

                    var res = client.GetAsync($"{apiUrl}/{id}").Result;

                    if (res.IsSuccessStatusCode)

                    {

                        var data = res.Content.ReadAsStringAsync().Result;

                        dto = JsonConvert.DeserializeObject<ProductDto>(data);

                    }

                }

            }

            if (dto == null)

                return HttpNotFound();

            PopulateStocksDropdowns(dto);

            return View(dto);

        }


        [HttpPost]

        public ActionResult Edit(int id, ProductDto dto)

        {

            if (!ModelState.IsValid)

            {

                PopulateStocksDropdowns(dto);

                return View(dto);

            }

            using (var handler = new HttpClientHandler())

            {

                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))

                {

                    var json = JsonConvert.SerializeObject(dto);

                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    var res = client.PutAsync($"{apiUrl}/{id}", data).Result;

                    if (res.IsSuccessStatusCode)

                        return RedirectToAction("Index");

                }

            }

            PopulateStocksDropdowns(dto);

            return View(dto);

        }

        public ActionResult Delete(int id)

        {

            ProductDto dto = null;

            using (var handler = new HttpClientHandler())

            {

                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))

                {

                    var res = client.GetAsync($"{apiUrl}/{id}").Result;

                    if (res.IsSuccessStatusCode)

                    {

                        var data = res.Content.ReadAsStringAsync().Result;

                        dto = JsonConvert.DeserializeObject<ProductDto>(data);

                    }

                }

            }

            if (dto == null)

                return HttpNotFound();

            return View(dto);

        }


        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)

        {

            using (var handler = new HttpClientHandler())

            {

                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))

                {

                    var res = client.DeleteAsync($"{apiUrl}/{id}").Result;

                    if (res.IsSuccessStatusCode)

                        return RedirectToAction("Index");

                }

            }

            return RedirectToAction("Index");

        }


        public ActionResult Reports()

        {

            List<StocksDto> stocks;

            using (var handler = new HttpClientHandler())

            {

                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))

                {

                    var res = client.GetAsync("https://localhost:44365/api/stocks").Result;

                    if (res.IsSuccessStatusCode)

                    {

                        var data = res.Content.ReadAsStringAsync().Result;

                        stocks = JsonConvert.DeserializeObject<List<StocksDto>>(data);

                    }

                    else

                    {

                        stocks = new List<StocksDto>();

                    }

                }

            }

            var report = stocks

                .GroupBy(s => new { s.Category, s.SubCategory })

                .Select(g => new StocksDto

                {

                    Category = g.Key.Category,

                    SubCategory = g.Key.SubCategory,

                    TotalStocks = g.Sum(x => x.TotalStocks) ?? 0,

                    AvailableStocks = g.Sum(x => x.AvailableStocks) ?? 0

                })

                .OrderBy(r => r.Category)

                .ThenBy(r => r.SubCategory)

                .ToList();

            return View(report);

        }


        #region Helper Methods

        private void PopulateStocksDropdowns(ProductDto dto = null)

        {

            List<StocksDto> stocks = new List<StocksDto>();

            using (var handler = new HttpClientHandler())

            {

                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                using (HttpClient client = new HttpClient(handler))

                {

                    var res = client.GetAsync(stocksApiUrl).Result;

                    if (res.IsSuccessStatusCode)

                    {

                        var data = res.Content.ReadAsStringAsync().Result;

                        stocks = JsonConvert.DeserializeObject<List<StocksDto>>(data);

                    }

                }

            }

            ViewBag.Categories = new SelectList(stocks.Select(s => s.Category).Distinct(), dto?.CategoryName);

            ViewBag.Stocks = stocks;

        }

        #endregion

    }

}
