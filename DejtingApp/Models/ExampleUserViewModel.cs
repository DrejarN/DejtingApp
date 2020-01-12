using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    public class ExampleUserViewModel
    {
        public int ProfileId { get; set; }
        public string Förnamn { get; set; }
        public DateTime Födelseår { get; set; }
        public string ImagePath { get; set; }
    }
}