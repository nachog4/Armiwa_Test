using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_EF_Template.Models;

namespace MVC_EF_Template.DAL
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            /*
            var products = new List<Product>
            {
                new Product {item = "A", price = 40, offer_quantity = 3, offer_price = 70 },
                new Product {item = "B", price = 10, offer_quantity = 2, offer_price = 15 },
                new Product {item = "C", price = 20, offer_quantity = 4, offer_price = 60 },
                new Product {item = "D", price = 30 }
            };

            products.ForEach(p => context.Products.Add(p));

            context.SaveChanges();
            */
        }
    }
}