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
                },
                new Pulcsi
                {
                    Name = "Cloud Dream Pulcsi",
                    Description = "As soft and light as a drifting cloud.",
                    Size = context.Sizes.First(x => x.SizeDes == "L"),
                    Price = 10299m
                },
                new Pulcsi
                {
                    Name = "Midnight Whisper Pulcsi",
                    Description = "Dark, elegant, and whisper-soft for chilly evenings.",
                    Size = context.Sizes.First(x => x.SizeDes == "M"),
                    Price = 10999m
                },
                new Pulcsi
                {
                    Name = "Pumpkin Spice Pulcsi",
                    Description = "Autumn vibes in every thread.",
                    Size = context.Sizes.First(x => x.SizeDes == "S"),
                    Price = 8999m
                },
                new Pulcsi
                {
                    Name = "Electric Pulse Pulcsi",
                    Description = "Bold lines and vibrant energy—feel the pulse.",
                    Size = context.Sizes.First(x => x.SizeDes == "XL"),
                    Price = 11499m
                },
                new Pulcsi
                {
                    Name = "Vintage Vibes Pulcsi",
                    Description = "Retro style meets modern comfort.",
                    Size = context.Sizes.First(x => x.SizeDes == "XXL"),
                    Price = 9799m
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
                    Name = "Arctic Breeze Pulcsi",
                    Description = "Stay cool and cozy in frosty hues.",
                    Size = context.Sizes.First(x => x.SizeDes == "M"),
                    Price = 10499m
                },
                new Pulcsi
                {
                    Name = "Cinnamon Cozy Pulcsi",
                    Description = "Warm, spicy, and perfect for lounging.",
                    Size = context.Sizes.First(x => x.SizeDes == "L"),
                    Price = 9399m
                },
                new Pulcsi
                {
                    Name = "Lava Flow Pulcsi",
                    Description = "Fiery design for the bold at heart.",
                    Size = context.Sizes.First(x => x.SizeDes == "XL"),
                    Price = 11299m
                },
                new Pulcsi
                {
                    Name = "Whispering Pine Pulcsi",
                    Description = "A forest-inspired classic for nature lovers.",
                    Size = context.Sizes.First(x => x.SizeDes == "XXL"),
                    Price = 9899m
                },
                new Pulcsi
                {
                    Name = "Moonlight Shadow Pulcsi",
                    Description = "Elegant and mysterious, like the night itself.",
                    Size = context.Sizes.First(x => x.SizeDes == "M"),
                    Price = 9999m
                },
                new Pulcsi
                {
                    Name = "Starlight Spark Pulcsi",
                    Description = "Shimmering threads catch every eye.",
                    Size = context.Sizes.First(x => x.SizeDes == "L"),
                    Price = 10699m
                },
                new Pulcsi
                {
                    Name = "Denim Dreams Pulcsi",
                    Description = "A sweater with a denim vibe.",
                    Size = context.Sizes.First(x => x.SizeDes == "S"),
                    Price = 9599m
                },
                new Pulcsi
                {
                    Name = "Neon Nights Pulcsi",
                    Description = "Vibe with the lights of the city.",
                    Size = context.Sizes.First(x => x.SizeDes == "XL"),
                    Price = 11199m
                },
                new Pulcsi
                {
                    Name = "Marshmallow Soft Pulcsi",
                    Description = "Sweet and softly embracing feel.",
                    Size = context.Sizes.First(x => x.SizeDes == "XXL"),
                    Price = 9499m
                },
                new Pulcsi
                {
                    Name = "Stormy Sky Pulcsi",
                    Description = "Dark tones with a dynamic style.",
                    Size = context.Sizes.First(x => x.SizeDes == "M"),
                    Price = 10099m
                },
                new Pulcsi
                {
                    Name = "Tangerine Pop Pulcsi",
                    Description = "Fresh and vibrant burst of color.",
                    Size = context.Sizes.First(x => x.SizeDes == "S"),
                    Price = 8999m
                },
                new Pulcsi
                {
                    Name = "Galaxy Fade Pulcsi",
                    Description = "Cosmic colors with down-to-earth comfort.",
                    Size = context.Sizes.First(x => x.SizeDes == "L"),
                    Price = 10899m
                },
                new Pulcsi
                {
                    Name = "Peachy Sunday Pulcsi",
                    Description = "Relaxed and light for easy Sundays.",
                    Size = context.Sizes.First(x => x.SizeDes == "XL"),
                    Price = 9399m
                },
                new Pulcsi
                {
                    Name = "Sunshine Yellow Pulcsi",
                    Description = "Brighten your day with this yellow pullover.",
                    Size = context.Sizes.First(x => x.SizeDes == "XXL"),
                    Price = 8999m
                }
                );
                context.SaveChanges();
            }
        }
    }
}
