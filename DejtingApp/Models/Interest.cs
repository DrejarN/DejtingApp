using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    public class Interest
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string InterestName { get; set; }
        
       
        public int ProfilePageId { get; set; }

        [ForeignKey("ProfilePageId")]
        public virtual ProfilePage ProfilePages { get; set; }



    }
}