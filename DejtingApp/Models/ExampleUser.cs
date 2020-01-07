using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    public class ExampleUser
    {
        
        [Display(Name = "Bild")]
        public string ImagePath { get; set; }

        [Display(Name = "Namn")]
        public string Förnamn { get; set; }

        [Display(Name = "Ålder")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Födelseår { get; set; }

    }
}