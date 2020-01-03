using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    public class Friend
    {
        [Key]
        public int FriendshipId { get; set; }

        //Skapar foreign key till Profile.ProfileId many-to-many
        [ForeignKey("Sender")]
        public int? SenderId { get; set; }
        public Profile Sender { get; set; }

        //Skapar foreign key till Profile.ProfileId many-to-many
        [ForeignKey("Reciever")]
        public int? RecieverId { get; set; }
        public Profile Reciever { get; set; }

        //Skapar foreign key till Category.CategoryId one-to-one
       
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }
    }
}