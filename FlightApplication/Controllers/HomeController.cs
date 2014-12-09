using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FlightApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            SqlConnection sqlConnection1 = new
            SqlConnection(ConfigurationManager.ConnectionStrings["Flights"].ConnectionString);

            //SqlConnection sqlConnection1 = new SqlConnection("Flights");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM dbo.flights";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            string info;

            try
            {
                while (reader.Read())
                {
                    info = String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", 
                        reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6],
                        reader[7], reader[8]);
                }
            }
            finally
            {
                reader.Close();
            }

            sqlConnection1.Close();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
