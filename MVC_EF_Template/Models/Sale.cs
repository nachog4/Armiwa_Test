using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_EF_Template.Models
{
    public class Sale
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Checkout String")]
        public string checkout_string { get; set; }

        [Display(Name = "Final Price")]
        public double final_price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}