using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    public class Profile
    {
        [Key]
        
        public int ProfileID { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public DateTime Födelseår { get; set; }
        public bool Active { get; set; }

        //[ForeignKey("ProfileId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}