using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SuppliersERP.Models
{
    public class Supplier : IValidatableObject
    {
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Full Name Required")]
        [MinLength(3, ErrorMessage = "Minimum Name Length=3 Characters")]
        [MaxLength(80, ErrorMessage = "Maximum Name Length=80 Characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "AFM Required")]
        [MinLength(9, ErrorMessage = "Required length=9 digits")]
        [MaxLength(9, ErrorMessage = "Required length=9 digits")]
        public string AFM { get; set; }

        [MinLength(5, ErrorMessage = "Minimum Name Length=5 Characters")]
        [MaxLength(100, ErrorMessage = "Maximum Name Length=100 Characters")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Email Required")]
        [Email]
        [MinLength(5, ErrorMessage = "Minimum Name Length=5 Characters")]
        [MaxLength(50, ErrorMessage = "Maximum Name Length=50 Characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Required")]
        [MinLength(10, ErrorMessage = "Required length=10 digits")]
        [MaxLength(10, ErrorMessage = "Required length=10 digits")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Please select the status of Supplier")]
        public bool Active { get; set; }


        [Required(ErrorMessage = "Please select  Category")]
        public int SupplierCategoryId { get; set; }



        [Required(ErrorMessage = "Please select  Country")]
        public int SupplierCountryId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!CheckAFM())
            {
                yield return new ValidationResult("AFM is not correct");
            }

            if (!CheckUniqueName())
            {
                yield return new ValidationResult("Full Name is not unique");
            }
        }

        private Boolean CheckAFM()
        {
            Int32 sum = 0;
            Int32 pointer = 1;
            Int64 dummyInt64 = 0;

            if (Int64.TryParse(AFM, out dummyInt64) && AFM.Length == 9)
            {
                if (dummyInt64 != 0)
                {
                    while (pointer < 9)
                    {
                        sum += Int32.Parse(AFM.Substring(pointer - 1, 1)) * Convert.ToInt32(Math.Pow(2, (9 - pointer)));
                        pointer++;
                    }
                    sum = sum % 11;
                    if (sum == 10)
                    {
                        sum = 0;
                    }
                    if (Int32.Parse(AFM.Substring(8, 1)) == sum)
                    {
                        pointer = 1;
                    }
                    else
                    {
                        pointer = 0;
                    }
                }
            }
            else
            {
                pointer = 0;
            }

            if (pointer != 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private Boolean CheckUniqueName()
        {
            var query = $"select SupplierId from dbo.Supplier where FullName='{FullName}'";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["SuppliersERPAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            if (table.Rows.Count>=1)
            {
                return false;
            }
            return true;
        }
    }
   
}