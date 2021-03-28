using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;

namespace WebAppSample.Controllers
{
    public class CreateErrorController : Controller
    {
        private readonly ILogger<CreateErrorController> _logger;

        public CreateErrorController(ILogger<CreateErrorController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Link()
        {
            return View();
        }

        public IActionResult ThrowException()
        {
            string value = Environment.GetEnvironmentVariable("sample");
            int finalValue = 100  / Convert.ToInt32(value);
            if (finalValue > 10)
                return View();
            else
                return View(10);
        }

        public IActionResult SlowPage()
        {
            var data = DateTime.Now;

            while (DateTime.Now.Subtract(data).TotalSeconds < 10)
                Thread.Sleep(100);


            return View();
        }

    }
}
