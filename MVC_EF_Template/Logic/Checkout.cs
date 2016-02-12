using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_EF_Template.DAL;

namespace MVC_EF_Template.Logic
{
    public class Product_Agrupation { public char Key { get; set; } public int Count { get; set; } }

    public class Checkout
    {


        public double Checkout_Process(string input_string)
        {
            string item;
            int? quantity = 0;
            double? price = 0;

            //GROUP PRODUCTS
            IEnumerable<Product_Agrupation> g = Group_Products(input_string);

            //CALL REPOSITORY
            Repositories.BaseService<Models.Product> repo = new Repositories.BaseService<Models.Product>(new DAL.DatabaseContext());
            Models.Product prod = new Models.Product();

            foreach (var i in g)
            {
                //VARS
                item = i.Key.ToString();
                quantity = i.Count;

                //FIND PRODUCT
                try {
                    prod = repo.Find(x => x.item.Equals(item));
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (quantity > 0 && prod != null)
                {
                    //CHECK FOR OFFERS APPLICABILITY
                    if (prod.offer_quantity != null)
                    {
                        while (quantity >= prod.offer_quantity && prod.offer_quantity != 0)
                        {
                            price = price + prod.offer_price;
                            quantity = quantity - prod.offer_quantity;
                        }
                    }

                    //NORMAL PRICES
                    price = price + (quantity * prod.price);
                }
            }

            //FINALIZE
            repo = null;

            return price.Value;

        }

        public IEnumerable<Product_Agrupation> Group_Products(string input_string)
        {
            IEnumerable<Product_Agrupation> g = from c in input_string.ToUpper().ToCharArray() // make sure that L and l are the same eg
                    group c by c into m
                    select new Product_Agrupation { Key = m.Key, Count = m.Count() };

            return g;
        }
    }
}