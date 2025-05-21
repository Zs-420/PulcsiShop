using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PulcsiShop.DAL;

namespace PulcsiShop.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private PulcsiShopDbContext _dbContext;

        public NavigationMenuViewComponent(PulcsiShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var sizeOrder = new List<string> { "XS", "S", "M", "L", "XL", "XXL", "XXXL" };

            var categories = _dbContext.Sizes
                .AsEnumerable()
                .Select(x => x.SizeDes)
                .OrderBy(x => sizeOrder.IndexOf(x.Trim().ToUpper()))
                .ToList();

            return View(categories);
        }
    }
}
