using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication3.Models;

namespace WebApplication3.Controllers
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
            ViewBag.ValuePara1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum id orci eget purus fermentum congue sit amet a nisl. Duis consectetur velit odio, non efficitur mauris congue eget. In lobortis magna quis nisi tincidunt pretium. Ut interdum, purus vel volutpat congue, quam tortor bibendum elit, non dignissim diam diam eu urna. Suspendisse a diam nec arcu dignissim aliquam a vitae felis. Aliquam erat volutpat. Vestibulum sit amet fringilla velit. Donec cursus vulputate maximus. Sed suscipit ultrices sagittis. Phasellus dapibus felis sed odio porta placerat et non augue.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Aparaty_His()
        {
            ViewBag.Title = "Aparaty tradycyjne - historia";
            ViewBag.ValuePara1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum id orci eget purus fermentum congue sit amet a nisl. Duis consectetur velit odio, non efficitur mauris congue eget. In lobortis magna quis nisi tincidunt pretium. Ut interdum, purus vel volutpat congue, quam tortor bibendum elit, non dignissim diam diam eu urna. Suspendisse a diam nec arcu dignissim aliquam a vitae felis. Aliquam erat volutpat. Vestibulum sit amet fringilla velit. Donec cursus vulputate maximus. Sed suscipit ultrices sagittis. Phasellus dapibus felis sed odio porta placerat et non augue.";
            return View("Aparaty_historia");
        }
        public IActionResult Aparaty_Foto_Podst()
        {
            ViewBag.Title = "Aparaty tradycyjne - historia";
            ViewBag.ValuePara1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum id orci eget purus fermentum congue sit amet a nisl. Duis consectetur velit odio, non efficitur mauris congue eget. In lobortis magna quis nisi tincidunt pretium. Ut interdum, purus vel volutpat congue, quam tortor bibendum elit, non dignissim diam diam eu urna. Suspendisse a diam nec arcu dignissim aliquam a vitae felis. Aliquam erat volutpat. Vestibulum sit amet fringilla velit. Donec cursus vulputate maximus. Sed suscipit ultrices sagittis. Phasellus dapibus felis sed odio porta placerat et non augue.";
            return View("Aparaty_foto_podst");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
