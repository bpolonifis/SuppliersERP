using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SuppliersERP.Models;

namespace SuppliersERP.Controllers
{
    public class SupplierController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"select SupplierId,
                        Sup.SupplierCategoryId,
                        Sup.SupplierCountryId,
                        FullName,
                          AFM, 
                         Address,
                         Email,
                         Phone,
                         IIF([Active]=1,'True','False') AS Active, 
                         SupCat.Category,
                         SupCou.Country
                         from 
                             dbo.Supplier AS Sup
                         inner join 
                             dbo.SupplierCategory AS SupCat ON Sup.SupplierCategoryId = SupCat.SupplierCategoryId
                         inner join 
                             dbo.SupplierCountry AS SupCou ON Sup.SupplierCountryId = SupCou.SupplierCountryId
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
        public string Post(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string query = @"
                       insert into dbo.Supplier(FullName,AFM,Address,Email,Phone,Active,SupplierCategoryId,SupplierCountryId) values
                      (
                       '" + supplier.FullName + @"'
                       ,'" + supplier.AFM + @"'
                       ,'" + supplier.Address + @"'
                       ,'" + supplier.Email + @"' 
                       ,'" + supplier.Phone + @"'
                       ,'" + supplier.Active + @"'
                       ,'" + supplier.SupplierCategoryId + @"'
                       ,'" + supplier.SupplierCountryId + @"'
                         
                      )
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

                    return "Added succesfully!!";
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

                return "Failed to add!!";
            }

        }

        public string Put(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string query = @"
                      update dbo.Supplier set 
                       FullName='" + supplier.FullName + @"'
                       ,AFM='" + supplier.AFM + @"'
                       ,Address='" + supplier.Address + @"'
                       ,Email='" + supplier.Email + @"'
                       ,Phone='" + supplier.Phone + @"'
                       ,Active='" + supplier.Active + @"'
                       ,SupplierCategoryId='" + supplier.SupplierCategoryId + @"'
                       where SupplierId=" + supplier.SupplierId + @"
                       ,SupplierCountryId='" + supplier.SupplierCountryId + @"'
                       where SupplierId=" + supplier.SupplierId + @"
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

                    return "Updated succesfully!!";
                }
                else
                {
                    var errorMessageList = ModelState.Values.SelectMany(o => o.Errors).Select(e => e.ErrorMessage).ToArray();
                    var errorMessage = $"Failed to Update! {string.Join(";", errorMessageList)}";
                    return errorMessage;
                }

                

            }
            catch (Exception ex)
            {

                return "Failed to update!!";
            }

        }
        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.Supplier 
                    where SupplierId=" + id + @"
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

                return "Deleted successfully!!";
            }
            catch (Exception ex)
            {

                return "Failed to delete!!";
            }
        }
        
        
    }
}
