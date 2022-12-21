using Scarpe_Co.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ScarpeDab"].ToString();
            con.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * from ArticoliTab";
            command.Connection= con;

            SqlDataReader reader = command.ExecuteReader();
            List<Articoli> articololist = new List<Articoli>();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    Articoli articolo = new Articoli();
                    articolo.IDArticolo = Convert.ToInt32(reader["IDArticolo"]);
                    articolo.NomeArticolo = reader["NomeArticolo"].ToString();
                    articolo.Costo = Convert.ToDouble(reader["Costo"]);
                    articolo.DescrizioneArticolo = reader["DescrizioneArticolo"].ToString();
                    articolo.IMGUrl = reader["IMGUrl"].ToString();
                    articolo.IMGGallery1 = reader["IMGGallery1"].ToString();
                    articolo.IMGGallery2 = reader["IMGGallery2"].ToString();
                    articolo.Visibile = Convert.ToBoolean(reader["Visibile"]);
                    articololist.Add(articolo);
                }
            }

            con.Close();
            return View(articololist);
        }
    }
}