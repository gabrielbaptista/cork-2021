using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebAppSample.Helper;
using WebAppSample.Models;
using WebAppSample.TOs;

namespace WebAppSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateError()
        {
            return View();
        }

        public async Task<IActionResult> Email()
        {
            string apiUrl = Environment.GetEnvironmentVariable("apiUrl"); 
            string api = Environment.GetEnvironmentVariable("api");
            WebHelper.SetApiUrl(apiUrl);
            await WebHelper.CallApi(HttpMethod.Post, api, GenerateObject());
            return View();
        }

        private EmailData GenerateObject()
        {
            EmailData emailData = new EmailData();
            emailData.To = "gabriel@smit.net.br";
            emailData.Subject = "App Insights Sample";
            emailData.Body = "Check how these things work together!";
            return emailData;
        }
    }
}
