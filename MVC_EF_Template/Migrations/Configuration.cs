namespace MVC_EF_Template.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_EF_Template.DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVC_EF_Template.DAL.DatabaseContext context)
        {
            var products = new List<Product>
            {
                new Product {item = "A", price = 40, offer_quantity = 3, offer_price = 70 },
                new Product {item = "B", price = 10, offer_quantity = 2, offer_price = 15 },
                new Product {item = "C", price = 20, offer_quantity = 4, offer_price = 60 },
                new Product {item = "D", price = 30 }
            };

            products.ForEach(p => context.Products.AddOrUpdate(p));

            context.SaveChanges();
        }
    }
}
