﻿using IKart_ClientSide.Filters;
using IKart_Shared.DTOs;
using IKart_Shared.DTOs.Admin;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IKart_Client.Controllers
{
    [AdminAuthorize]
    public class EmiCardController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:44365/api/emicards";

        public async Task<ActionResult> Index()
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                using (var client = new HttpClient(handler))
                {
                    var response = await client.GetStringAsync(apiBaseUrl);
                    var cards = JsonConvert.DeserializeObject<List<EmiCardDto>>(response);
                    return View(cards);
                }
            }
        }

        public async Task<ActionResult> View(int id)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                using (var client = new HttpClient(handler))
                {
                    var response = await client.GetStringAsync($"{apiBaseUrl}/{id}");
                    var card = JsonConvert.DeserializeObject<EmiCardDto>(response);
                    return View(card);
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateStatus(int id, string status)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                using (var client = new HttpClient(handler))
                {
                    var content = new StringContent($"\"{status}\"", Encoding.UTF8, "application/json");
                    var response = await client.PutAsync($"{apiBaseUrl}/updatestatus/{id}", content);

                    if (response.IsSuccessStatusCode)
                        TempData["Message"] = "Status updated successfully!";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
