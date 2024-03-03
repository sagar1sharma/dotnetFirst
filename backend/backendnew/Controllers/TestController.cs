using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using backendnew.Models;

namespace backendnew.Controllers
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd = null;
        SqlDataAdapter adapter = null;

        [HttpPost]
        [Route("Registeration")]

        public string Registeration(User user)
        {
            String msg = string.Empty;
            try
            {
                cmd = new SqlCommand("usp_Registeration", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@PhoneNo", user.PhoneNo);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);

                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                {
                    msg = "Data inserted.";
                }
                else
                {
                    msg = "Error";
                }
            }
            catch (Exception ex)
            {
                msg = "yahan dikkat hai";
            }


            return msg;
        }

        [HttpPost]
        [Route("Login")]

        public string Login(User user)
        {
            String msg = string.Empty;
            try
            {
                adapter = new SqlDataAdapter("usp_Login", conn);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Name", user.Name);
                adapter.SelectCommand.Parameters.AddWithValue("PhoneNo", user.PhoneNo);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                if(dt.Rows.Count > 0)
                {
                    msg = "User is Valid";
                }
                else
                {
                    msg = "User is Invalid";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }


            return msg;
        }
    }
}
