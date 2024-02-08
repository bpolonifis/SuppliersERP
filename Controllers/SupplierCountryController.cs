using SuppliersERP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuppliersERP.Controllers
{
    public class SupplierCountryController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select SupplierCountryId,Country from
                    dbo.SupplierCountry
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["SuppliersERPAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);




        }
        public string Post(SupplierCountry suplCou)
        {
            try              
            {
                if (ModelState.IsValid)
                {
                    string query = @"
                      insert into dbo.SupplierCountry values
                      ('" + suplCou.Country + @"')
                      ";
                    DataTable table = new DataTable();
                    using (var con = new SqlConnection(ConfigurationManager.
                        ConnectionStrings["SuppliersERPAppDB"].ConnectionString))
                    using (var cmd = new SqlCommand(query, con))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }

                    return "Added Succesfully!!";
                }
                else
                {
                    var errorMessageList = ModelState.Values.SelectMany(o => o.Errors).Select(e => e.ErrorMessage).ToArray();
                    var errorMessage = $"Failed to Add!! {string.Join(";", errorMessageList)}";
                    return errorMessage;
                }
                

            }
            catch (Exception ex)
            {

                return "Failed to Add!!";
            }

        }

        public string Put(SupplierCountry suplCou)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string query = @"
                      update dbo.SupplierCountry set Country=
                      '" + suplCou.Country + @"'
                       where SupplierCountry=" + suplCou.SupplierCountryId + @"
                      ";
                    DataTable table = new DataTable();
                    using (var con = new SqlConnection(ConfigurationManager.
                        ConnectionStrings["SuppliersERPAppDB"].ConnectionString))
                    using (var cmd = new SqlCommand(query, con))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.Text;
                        da.Fill(table);
                    }

                    return "Updated Succesfully!!";
                }
                else
                {
                    var errorMessageList = ModelState.Values.SelectMany(o => o.Errors).Select(e => e.ErrorMessage).ToArray();
                    var errorMessage =$"Failed to Update!! {string.Join(";", errorMessageList)}";
                    return errorMessage;
                }
               
            }
                
            catch (Exception ex)
            {

                return "Failed to Update!!";
            }

        }
        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.SupplierCountry 
                    where SupplierCountryId=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["SuppliersERPAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }
        

    }
}
