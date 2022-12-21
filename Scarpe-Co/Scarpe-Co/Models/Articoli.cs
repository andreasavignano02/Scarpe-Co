using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Scarpe_Co.Models
{
    public class Articoli
    {
        public int IDArticolo { get; set; }

        [Display(Name = "Nome Articolo")]
        [Required(ErrorMessage = "Nome Obbligatorio")]
        public string NomeArticolo { get; set; }

        [Display(Name = "Costo dell'articolo")]
        [Required(ErrorMessage = "Inserire un prezzo")]
        public double Costo { get; set; }

        [Display(Name = "Descrizione dell'articolo")]
        [Required(ErrorMessage = "Inserire una descrizione")]
        public string DescrizioneArticolo { get; set; }

        [Display(Name = "Immagine di copertina dell'articolo")]
        [Required(ErrorMessage = "Inserire un' immagine di copertina")]
        public string IMGUrl { get; set; }

        [Display(Name = "Prima immagine dell'articolo")]
        [Required(ErrorMessage = "Inserire un'immagine")]
        public string IMGGallery1 { get; set; }

        [Display(Name = "Prima immagine dell'articolo")]
        [Required(ErrorMessage = "Inserire un'immagine")]
        public string IMGGallery2 { get; set; }

        public bool Visibile { get; set; }
    }
}