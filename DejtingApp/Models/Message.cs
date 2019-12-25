using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public DateTime MessageCreated { get; set; }

        [ForeignKey("Sender")]
        public int? SenderId { get; set; }
        public ProfilePage Sender { get; set; }

        [ForeignKey("Reciever")]
        public int? RecieverId { get; set; }
        public ProfilePage Reciever { get; set; }

    }
}