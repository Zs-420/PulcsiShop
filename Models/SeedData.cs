using Microsoft.EntityFrameworkCore;
using PulcsiShop.DAL;
using System.Reflection;
using System.Security.Claims;
namespace PulcsiShop.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            PulcsiShopDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PulcsiShopDbContext>();
            if (context.Database.GetPendingMigrations().Any())  //Nem szedhetjük ki
            {
                context.Database.Migrate();
            }
            if (!context.Pulcsik.Any())
            {
                context.Sizes.AddRange(
                new Size
                {
                    SizeDes = "S"
                },
                new Size
                {
                    SizeDes = "M"
                },
                new Size
                {
                    SizeDes = "L"
                },
                new Size
                {
                    SizeDes = "XL"
                },
                new Size
                {
                    SizeDes = "XXL"
                }
                );
                context.SaveChanges();

                context.Pulcsik.AddRange(
                new Pulcsi
                {
                    Name = "Cosy Winter Hoodie",
                    Description = "A warm and soft hoodie, perfect for chilly winter days.",
                    Size = context.Sizes.First(x => x.SizeDes == "S"),
                    Price = 18999m
                },
                new Pulcsi
                {
                    Name = "Minimalist Black Pullover",
                    Description = "Sleek and simple design for everyday wear.",
                    Size = context.Sizes.First(x => x.SizeDes == "M"),
                    Price = 23999m
                },
                new Pulcsi
                {
                    Name = "Vintage College Sweater",
                    Description = "Retro vibes with classic college print.",
                    Size = context.Sizes.First(x => x.SizeDes == "L"),
                    Price = 28999m
                },
                new Pulcsi
                {
                    Name = "Oversized Streetwear Hoodie",
                    Description = "Comfy and stylish for casual urban outfits.",
                    Size = context.Sizes.First(x => x.SizeDes == "XL"),
                    Price = 14999m
                },
                new Pulcsi
                {
                    Name = "Pastel Pink Pulcsi",
                    Description = "Cute and comfy pullover in a soft pastel shade.",
                    Size = context.Sizes.First(x => x.SizeDes == "M"),
                    Price = 11999m
                },
                new Pulcsi
                {
                    Name = "Pastel Pink Pulcsi",
                    Description = "Cute and comfy pullover in a soft pastel shade.",
                    Size = context.Sizes.First(x => x.SizeDes == "S"),
                    Price = 11999m
                },
                new Pulcsi
                {
                    Name = "Pastel Pink Pulcsi",
                    Description = "Cute and comfy pullover in a soft pastel shade.",
                    Size = context.Sizes.First(x => x.SizeDes == "L"),
                    Price = 11999m
                },
                new Pulcsi
                {
                    Name = "Pastel Pink Pulcsi",
                    Description = "Cute and comfy pullover in a soft pastel shade.",
                    Size = context.Sizes.First(x => x.SizeDes == "XL"),
                    Price = 11999m
                },
                new Pulcsi
                {
                    Name = "Pastel Pink Pulcsi",
                    Description = "Cute and comfy pullover in a soft pastel shade.",
                    Size = context.Sizes.First(x => x.SizeDes == "XXL"),
                    Price = 11999m
                },
                new Pulcsi
                {
                    Name = "Ocean Blue Pulcsi",
                    Description = "A breezy pullover in deep ocean blue.",
                    Size = context.Sizes.First(x => x.SizeDes == "S"),
                    Price = 10999m
                },
                new Pulcsi
                {
                    Name = "Ocean Blue Pulcsi",
                    Description = "A breezy pullover in deep ocean blue.",
                    Size = context.Sizes.First(x => x.SizeDes == "M"),
                    Price = 10999m
                },
                new Pulcsi
                {
                    Name = "Ocean Blue Pulcsi",
                    Description = "A breezy pullover in deep ocean blue.",
                    Size = context.Sizes.First(x => x.SizeDes == "L"),
                    Price = 10999m
                },
                new Pulcsi
                {
                    Name = "Mint Green Pulcsi",
                    Description = "Fresh and soft mint-colored pullover.",
                    Size = context.Sizes.First(x => x.SizeDes == "XL"),
                    Price = 9999m
                },
                new Pulcsi
                {
                    Name = "Mint Green Pulcsi",
                    Description = "Fresh and soft mint-colored pullover.",
                    Size = context.Sizes.First(x => x.SizeDes == "XXL"),
                    Price = 9999m
                },
                new Pulcsi
                {
                    Name = "Sunshine Yellow Pulcsi",
                    Description = "Brighten your day with this yellow pullover.",
                    Size = context.Sizes.First(x => x.SizeDes == "S"),
                    Price = 8999m
                },
                new Pulcsi
                {
                    Name = "Sunshine Yellow Pulcsi",
                    Description = "Brighten your day with this yellow pullover.",
                    Size = context.Sizes.First(x => x.SizeDes == "M"),
                    Price = 8999m
                },
                new Pulcsi
                {
                    Name = "Lavender Dream Pulcsi",
                    Description = "Relaxed vibes in a soft lavender hue.",
                    Size = context.Sizes.First(x => x.SizeDes == "L"),
                    Price = 11999m
                },
                new Pulcsi
                {
                    Name = "Lavender Dream Pulcsi",
                    Description = "Relaxed vibes in a soft lavender hue.",
                    Size = context.Sizes.First(x => x.SizeDes == "XL"),
                    Price = 11999m
                },
                new Pulcsi
                {
                    Name = "Lavender Dream Pulcsi",
                    Description = "Relaxed vibes in a soft lavender hue.",
                    Size = context.Sizes.First(x => x.SizeDes == "XXL"),
                    Price = 11999m
                },
                new Pulcsi
                {
                    Name = "Eco-Friendly Fleece",
                    Description = "Made from recycled materials, soft and sustainable.",
                    Size = context.Sizes.First(x => x.SizeDes == "L"),
                    Price = 9999m
                });
                context.SaveChanges();
            }
        }
    }
}
