using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    public class MessageViewModel
    {
        public string MessageText { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public DateTime Datum { get; set; }
        public int? Reciever { get; set; }
    }
}