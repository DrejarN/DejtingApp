﻿using System;
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


        //InverseProperty möjliggör many-to-many förhållande i DB från friends/friendReqs
        [InverseProperty("Sender")]
        public ICollection<Friend> Senders { get; set; }

        [InverseProperty("Reciever")]
        public ICollection<Friend> Recievers { get; set; }

        [InverseProperty("Sender")]
        public ICollection<FriendRequest> Senders1 { get; set; } //this name ok?

        [InverseProperty("Reciever")]
        public ICollection<FriendRequest> Recievers2 { get; set; } //this name ok?

    }
}