using Microsoft.EntityFrameworkCore;
using PulcsiShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PulcsiShop.DAL
{
    public class PulcsiShopDbContext : IdentityDbContext<IdentityUser>
    {
        public PulcsiShopDbContext(DbContextOptions<PulcsiShopDbContext>
        options) : base(options)
        { }

        public DbSet<Pulcsi> Pulcsik { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Size> Sizes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });
            //create user
            var appUser = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "admin@pulcsishop.hu",
                EmailConfirmed = true,
                UserName = "admin@pulcsishop.hu",
                NormalizedUserName = "admin@pulcsishop.hu"
            };
            //set user password
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Pulcsi123$");
            //seed user
            builder.Entity<IdentityUser>().HasData(appUser);
            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
}
