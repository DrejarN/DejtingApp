using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    public class FriendRequest
    {
        [Key]
        public int FriendRequestId { get; set; }

        //Skapar foreign key till Profile.ProfileId
        [ForeignKey("Sender")]
        public int? SenderId { get; set; }
        public Profile Sender { get; set; }

        //Skapar foreign key till Profile.ProfileId
        [ForeignKey("Reciever")]
        public int? RecieverId { get; set; }
        public Profile Reciever { get; set; }

    }
}