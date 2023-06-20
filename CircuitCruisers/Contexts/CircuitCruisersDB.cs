using CircuitCruisers.Models.Entities;
using CircuitCruisers.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CircuitCruisers.Contexts
{
    public class CircuitCruisersDB : IdentityDbContext<AppUser>
    {
        public CircuitCruisersDB(DbContextOptions<CircuitCruisersDB> options) : base(options)
        {
        }

        public DbSet<CategoryEntity> Categories { get; set; } = null!;
        public DbSet<ImageEntity> Images { get; set; } = null!;
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; } = null!;
        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<ProductImageEntity> ProductImages { get; set; } = null!;
        public DbSet<ProductReviewEntity> ProductReviews { get; set; } = null!;
        public DbSet<ProductTagEntity> ProductTags { get; set; } = null!;
        public DbSet<TagEntity> Tags { get; set; } = null!;
        public DbSet<VendorEntity> Vendors { get; set; } = null!;
        public DbSet<ContactFormEntity> ContactForms { get; set; } = null!;
        public DbSet<AddressEntity> AspNetAddresses { get; set; } = null!;
        public DbSet<UserAddressEntity> AspNetUsersAddresses { get; set; } = null!;

    }
}



//protected override void OnModelCreating(ModelBuilder builder)
//{
//    base.OnModelCreating(builder);


//    var roleId = Guid.NewGuid().ToString();
//    var userId = Guid.NewGuid().ToString();

//    builder.Entity<IdentityRole>().HasData(
//        new IdentityRole
//        {
//            Id = roleId,
//            Name = "SystemAdministrator",
//            NormalizedName = "SYSTEMADMINISTRATOR",
//        });

//    var passwordHasher = new PasswordHasher<AppUser>();

//    builder.Entity<AppUser>().HasData(new AppUser
//    {
//        Id = userId,
//        FirstName = "",
//        LastName = "",
//        UserName = "administrator@domain.com",
//        Email = "Administrator@domain.com",
//        PasswordHash = passwordHasher.HashPassword(null!,"ChangePassword123!")
//    });

//    builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
//    {
//        RoleId = roleId,
//        UserId = userId
//    });

//}