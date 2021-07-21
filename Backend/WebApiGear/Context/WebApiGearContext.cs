using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApiGear.Models;
using WebApiGear.Models.Identity;

namespace WebApiGear.Context
{
    public class WebApiGearContext: IdentityDbContext
    {
        public WebApiGearContext(DbContextOptions<WebApiGearContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> AspNetUsers { get; set; }
        public DbSet<LocationModel> LocationCity { get; set; }
        public DbSet<ProductsModel> Products { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<TrademarkModel> Trademark { get; set; }
        public DbSet<PurchaseDetailModel> purchaseDetails { get; set; }
        public DbSet<ShoppingCartModel> ShoppingCart { get; set; }
        public DbSet<PaymentMethodModel> PaymentMethod { get; set; }
        public DbSet<PaymentsModel> Payments { get; set; }
        public DbSet<PaymentOrderModel> PaymentOrder { get; set; }
        public DbSet<PaymentOrderStatusModel> PaymentOrderStatus { get; set; }


    }
}
//add-migration
//dotnet ef database update