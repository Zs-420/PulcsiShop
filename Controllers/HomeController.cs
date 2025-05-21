using Microsoft.AspNetCore.Mvc;
using PulcsiShop.Models;
using System.Diagnostics;
using PulcsiShop.DAL;
using Microsoft.EntityFrameworkCore;

namespace PulcsiShop.Controllers
{         
     public class HomeController : Controller
     {
            private readonly ILogger<HomeController> _logger;
            private PulcsiShopDbContext _dbContext;
            public HomeController(ILogger<HomeController> logger, PulcsiShopDbContext
             dbContext)
            {
                _logger = logger;
                _dbContext = dbContext;
            }

        /*public IActionResult Index()
        {
            Pulcsi pulcsi = new Pulcsi()
            {
                Name = "Valami",
                Price = 3200,
                Description = "Bla-bla . . .",
                Size = "XL"
            };
            _dbContext.Pulcsik.Add(pulcsi);
            _dbContext.SaveChanges();
            return View(_dbContext.Pulcsik);         
        }*/

        public IActionResult Index(string category)
        {
            var pulcsik = _dbContext.Pulcsik.Include(s => s.Size).Where(x => category == null || x.Size.SizeDes == category);
            ViewBag.SelectedCategory = category;
            return View(pulcsik);
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
