using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_EF_Template.Logic;
using System.Collections.Generic;

namespace Tests_Project
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //The Class gets data through Entity Framework so its not possible to test as "Unit Test" but as an integration Test
            //This would be an example of a Unit Test for the case

            string checkout_string = "ABAABCDB";
            double result;
            double expected = 145;

            Checkout checkout = new Checkout();
            result = checkout.Checkout_Process(checkout_string);

            Assert.AreEqual(expected, result, "Result is not correct");
        }

        [TestMethod]
        public void TestMethod2()
        {
            string checkout_string = "ABAABCDB";
            IEnumerable<Product_Agrupation> pa;
            Checkout checkout = new Checkout();
            pa = checkout.Group_Products(checkout_string);

           foreach (var i in pa)
            {
                if (i.Key.ToString() == "A") { Assert.AreEqual(3, i.Count); }
                if (i.Key.ToString() == "B") { Assert.AreEqual(3, i.Count); }
                if (i.Key.ToString() == "C") { Assert.AreEqual(1, i.Count); }
                if (i.Key.ToString() == "D") { Assert.AreEqual(1, i.Count); }
            }

        }
    }
}
