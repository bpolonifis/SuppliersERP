using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SuppliersERP.Models
{
    public class SupplierCategory
    {
        public int SupplierCategoryId { get; set; }
        [Required(ErrorMessage = "Please Select a Name For the Category")]
        public string Category { get; set; }

    }
}