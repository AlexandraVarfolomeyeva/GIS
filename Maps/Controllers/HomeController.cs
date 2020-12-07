using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Maps.Models;
using Maps.ViewModel;

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

        [HttpPost]
        public IActionResult addMinimum([FromBody] MinimumViewModel minimum) //получить все 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("addMinimum " + "Валидация внутри контроллера неудачна.");
                    return BadRequest(ModelState);
                }
                Console.WriteLine("addMinimum "+ "Данные валидны.");

                TransformerSubstation TS = new TransformerSubstation()
                {
                    Address = minimum.SubAddress,
                    CoordinatesX = minimum.CoordX,
                    CoordinatesY = minimum.CoordY,
                    BuilderId=1,
                    ProjectId=1,
                    StateId=2,
                    Name="новая своя ТП",
                    Floors=1,
                    Session = DateTime.Now,
                    Minimum = minimum.Value,
                    YearDone = DateTime.Now.Year,
                    YearFinish = DateTime.Now.Year,
                    YearStart = DateTime.Now.Year
                };
                _context.TransformerSubstation.Add(TS);
                _context.SaveChanges();
                IActionResult res = CreatedAtAction("GetTS", new { id = TS.Id }, TS);
                Console.WriteLine("res "+ res.ToString() +"\n id:"+ TS.Id);
                for (int i =0; i < minimum.ConsCoord.Length/2; i++)
                {
                    Consumer cns = new Consumer()
                    {
                        Address = "",
                        CoordinatesX = minimum.ConsCoord[i,0],
                        CoordinatesY = minimum.ConsCoord[i,1],
                        SubstationId = TS.Id
                    };
                    _context.Consumers.Add(cns);
                }
                _context.SaveChanges();
                return Ok(TS.Id);
            }
            catch (Exception ex)
            {//если что-то пошло не так, выводим исключение в консоль
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        public IActionResult UpdateMinimum([FromBody] MinimumViewModel minimum)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("UpdateMinimum " + "Валидация внутри контроллера неудачна.");
                    return BadRequest(ModelState);
                }
                Console.WriteLine("UpdateMinimum " + "Данные валидны.");
                TransformerSubstation TS =_context.TransformerSubstation.Find(minimum.Id);

                TS.Address = minimum.SubAddress;
                TS.CoordinatesX = minimum.CoordX;
                TS.CoordinatesY = minimum.CoordY;
                TS.Minimum = minimum.Value;

                _context.TransformerSubstation.Update(TS);
                _context.SaveChanges();
                
                for (int i = 0; i < minimum.ConsCoord.Length / 2; i++)
                {
                    List<Consumer> cnsmrs = _context.Consumers.Where(a=>a.CoordinatesX==minimum.ConsCoord[i,0] && a.CoordinatesY == minimum.ConsCoord[i, 1]).ToList();
                  if (cnsmrs.Count() == 0)//если такого нет
                    {
                        Consumer cns = new Consumer()//добавляем
                    {
                        Address = "",
                        CoordinatesX = minimum.ConsCoord[i, 0],
                        CoordinatesY = minimum.ConsCoord[i, 1],
                        SubstationId = TS.Id
                    };
                    _context.Consumers.Add(cns);
                    }
                        
                }
                _context.SaveChanges();
                return Ok(TS.Id);
            }
            catch (Exception ex)
            {//если что-то пошло не так, выводим исключение в консоль
                Console.WriteLine(ex);
                return BadRequest();
            }
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
