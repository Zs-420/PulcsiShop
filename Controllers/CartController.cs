using PulcsiShop.DAL;
using PulcsiShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PulcsiShop.Controllers
{
    public class CartController : Controller
    {
        private PulcsiShopDbContext _dbContext;

        public CartController(PulcsiShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session,"cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }

        [Route("buy/{id}")]
        public IActionResult Buy(long id)
        {
            List<Item>? cart =
            SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item { Product = _dbContext.Pulcsik.Find(id), Quantity = 1 });
            }
            else
            {
                int index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = _dbContext.Pulcsik.Find(id), Quantity = 1 });
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(long id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = IsExist(id);

            if (index != -1)    //Ellenőrizni kell a kosár tartalmát, ne legyen üres
            {
                if (cart[index].Quantity > 1)
                {
                    cart[index].Quantity--;
                }
                else
                {
                    cart.RemoveAt(index);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else if (index == -1)
            {
                TempData["error"] = "A termék nem található a kosárban.";
                return RedirectToAction("Index");
            }

            /*
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            if (cart[index].Quantity > 1) cart[index].Quantity--;
            else cart.RemoveAt(index);
            */

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult CheckOut()
        {
            return View("CheckOut");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckOut(Order order)
        {
            if (ModelState.IsValid)
            {
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                order.TotalPrice = (int)cart.Sum(item => item.Product.Price * item.Quantity);
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();
                cart = null;
                HttpContext.Session.Clear();
                return View("CheckOut2", order);
            }
            return View("CheckOut");
        }

        private int IsExist(long id)
        {
            List<Item> cart =
            SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int i = 0;
            while (i < cart.Count && cart[i].Product.PulcsiID != id)
            {
                i++;
            }
            if (i < cart.Count) return i;
            else return -1;
        }
    }
}
