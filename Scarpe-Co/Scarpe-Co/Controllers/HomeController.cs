using Scarpe_Co.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
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
            command.CommandText = "Select * from ArticoliTab where visibile = 1";
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

        [HttpGet]
        public ActionResult About(int id)
        {
            SqlConnection con = new SqlConnection();
            Articoli articolo = new Articoli();
            try
            {
                
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ScarpeDab"].ToString();
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.CommandText = "SELECT * FROM ArticoliTab WHERE IDArticolo = @ID";
                cmd.Connection = con;

                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        articolo.IDArticolo = id;
                        articolo.NomeArticolo = reader["NomeArticolo"].ToString();
                        articolo.Costo = Convert.ToDouble(reader["Costo"]);
                        articolo.DescrizioneArticolo = reader["DescrizioneArticolo"].ToString();
                        articolo.IMGUrl = reader["IMGUrl"].ToString();
                        articolo.IMGGallery1 = reader["IMGGallery1"].ToString();
                        articolo.IMGGallery2 = reader["IMGGallery2"].ToString();
                        articolo.Visibile = Convert.ToBoolean(reader["Visibile"]);
                    }
                }
            }
            catch(Exception ex)
            {
                con.Close();
            }
            con.Close();
            return View(articolo);
        }

        [HttpGet]
        public ActionResult ChangeVisible(int id)
        {
            SqlConnection con = new SqlConnection();
            Articoli articolo = new Articoli();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ScarpeDab"].ToString();
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.CommandText = "select * from ArticoliTab where IDArticolo = @ID";
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        articolo.IDArticolo = id;
                        articolo.Visibile = Convert.ToBoolean(reader["Visibile"]);
                    }
                }
            }
            catch(Exception ex) 
            { 
                con.Close(); 
            }
            con.Close();
            return View(articolo);
        }

        [HttpPost]
        public ActionResult ChangeVisible(Articoli articolo, int id) 
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ScarpeDab"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("Visibile", articolo.Visibile);

                command.CommandText = "UPDATE ArticoliTab SET Visibile = @Visibile WHERE IDArticolo = @ID";
                command.Connection = con;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            con.Close();
            return RedirectToAction("index");
        }
    }
}