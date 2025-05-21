using PulcsiShop.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PulcsiShop.Models;
using Microsoft.EntityFrameworkCore;

namespace PulcsiShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderHandling : Controller
    {
        private PulcsiShopDbContext _dbContext;
        public OrderHandling(PulcsiShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        public IActionResult Delete(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order); // megjeleníti a törlés megerősítő nézetet
        }

        // POST: OrderHandling/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _dbContext.Orders.Find(id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Index()
        {
            //var orders = _dbContext.Orders;
            var orders = _dbContext.Orders.ToList();
            return View(orders);
        }        
    }
}
