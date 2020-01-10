using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    [JsonObject(IsReference = true)]
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public DateTime Födelseår { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public string ImagePath { get; set; }

        [JsonIgnore]
        public string ApplicationUser { get; set; }
        [JsonIgnore]
        [ForeignKey("ApplicationUser")]
        public virtual ApplicationUser AppUser { get; set; }

        //InverseProperty möjliggör many-to-many förhållande i DB från friends/friendReqs
        [InverseProperty("Sender")]
        [JsonIgnore]
        public ICollection<Friend> Senders { get; set; }

        [InverseProperty("Reciever")]
        [JsonIgnore]
        public ICollection<Friend> Recievers { get; set; }

        [InverseProperty("Sender")]
        [JsonIgnore]
        public ICollection<FriendRequest> Senders1 { get; set; } //this name ok?

        [InverseProperty("Reciever")]
        [JsonIgnore]
        public ICollection<FriendRequest> Recievers2 { get; set; } //this name ok?

        [InverseProperty("Sender")]
        [JsonIgnore]
        public ICollection<Message> Senders3 { get; set; }

        [InverseProperty("Reciever")]
        [JsonIgnore]
        public ICollection<Message> Recievers3 { get; set; }

        [InverseProperty("Sender")]
        [JsonIgnore]
        public ICollection<ProfileView> Senders4 { get; set; }

        [InverseProperty("Reciever")]
        [JsonIgnore]
        public ICollection<ProfileView> Receiever4 { get; set; }


    }
}