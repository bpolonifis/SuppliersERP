using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SuppliersERP.Models
{
    public class SupplierCountry
    {
        public int SupplierCountryId { get; set; }
        [Required(ErrorMessage = "Please Select a Country")]
        public string Country { get; set; }
    }
}