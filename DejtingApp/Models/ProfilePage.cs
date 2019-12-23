using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    public class ProfilePage
    {
        [Key]
        [Required]
        public int ProfilePageId { get; set; }

        [Required]
        public string Description { get; set; }

        //En prop för profilbild
    }
}