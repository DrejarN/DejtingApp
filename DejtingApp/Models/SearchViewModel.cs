using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DejtingApp.Models
{
    public class SearchViewModel
    {
        public int ProfileId { get; set; }
        public string ImagePath { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }

        [Display(Name = "Ålder")]
        public DateTime Födelseår { get; set; }

    }
}