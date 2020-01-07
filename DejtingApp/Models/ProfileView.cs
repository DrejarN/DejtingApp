using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    public class ProfileView
    {
        [Key]
        public int ProfileViewId { get; set; }

        [ForeignKey("Sender")]
        public int? SendClickId { get; set; }
        public Profile Sender { get; set; }


        [ForeignKey("Reciever")]
        public int? RecieveClickId { get; set; }
        public Profile Reciever { get; set; }
    }
}