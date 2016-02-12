using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_EF_Template.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Item")]
        [MaxLength(1, ErrorMessage = "Max Lenght 1 Character")]
        public string item { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double price { get; set; }

        [Display(Name = "Offer Quantity")]
        public int? offer_quantity { get; set; }

        [Display(Name = "Offer Price")]
        public double? offer_price { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
