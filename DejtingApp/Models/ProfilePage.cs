using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public virtual Profile Profile { get; set; }

        [InverseProperty("Sender")]
        public ICollection<Message> Senders { get; set; }

        [InverseProperty("Reciever")]
        public ICollection<Message> Recievers { get; set; }


    }
}