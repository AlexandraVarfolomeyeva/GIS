using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Maps.Models;

namespace Maps.Controllers
{
    public class HomeController : Controller
    {
        private readonly TransmissionContext _context;

        public HomeController(TransmissionContext context)
        {
            _context = context; // получаем контекст базы данных
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<TransformerSubstation> GetAll() //получить все 
        {
            try
            {
                IEnumerable<TransformerSubstation> b = _context.TransformerSubstation;
                return b;
            }
            catch (Exception ex)
            {//если что-то пошло не так, выводим исключение в консоль
                Console.WriteLine("Возникла ошибка при получении списка.");
                return null;
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
