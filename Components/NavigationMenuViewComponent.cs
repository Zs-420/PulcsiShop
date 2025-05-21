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
            //var categories = _dbContext.Pulcsik.Select(x => x.Size).Distinct().OrderBy(x => x);
            var categories = _dbContext.Sizes.Select(x => x.SizeDes).OrderBy(x => x);
            return View(categories);
        }
    }
}
