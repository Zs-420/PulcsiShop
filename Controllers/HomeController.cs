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

        public IActionResult Index(string category, string keyword)
        {
            var pulcsik = _dbContext.Pulcsik
                .Include(p => p.Size)
                .Where(p =>
                    (string.IsNullOrEmpty(category) || p.Size.SizeDes == category) &&
                    (string.IsNullOrEmpty(keyword) || p.Name.ToLower().Contains(keyword.ToLower()) || p.Description.ToLower().Contains(keyword.ToLower()) || p.Size.SizeDes.ToLower().Contains(keyword.ToLower()))
                );

            ViewBag.SelectedCategory = category;
            ViewBag.Keyword = keyword;

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
