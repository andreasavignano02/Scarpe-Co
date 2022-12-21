using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scarpe_Co.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SqlConnection con = new SqlConnection();
            con.Open();
            con.Close();
            return View();
        }
    }
}