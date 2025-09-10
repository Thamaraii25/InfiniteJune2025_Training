﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using IKart_ClientSide.Filters;
using IKart_Shared.DTOs.Admin;
using Newtonsoft.Json;

namespace IKart_Client.Controllers.Admin
{
    [AllowAnonymous]
    [AdminAuthorize]
    public class DashboardController : Controller
    {
        private readonly string apiUrl = "https://localhost:44365/api/dashboard";

        public async Task<ActionResult> Index()
        {
            List<OrderDto> orders = new List<OrderDto>();
            object tokens = null;
            object revenue = null;

            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

                using (var client = new HttpClient(handler))
                {
                    var tokensResponse = await client.GetStringAsync(apiUrl + "/tokens");
                    var ordersResponse = await client.GetStringAsync(apiUrl + "/recent-orders");
                    var revenueResponse = await client.GetStringAsync(apiUrl + "/revenue");

                    tokens = JsonConvert.DeserializeObject(tokensResponse);
                    orders = JsonConvert.DeserializeObject<List<OrderDto>>(ordersResponse);
                    revenue = JsonConvert.DeserializeObject(revenueResponse);
                }
            }

            ViewBag.Tokens = tokens;
            ViewBag.Revenue = revenue;

            return View(orders); 
        }
    }
}
