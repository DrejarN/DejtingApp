using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        public string ImageName { get; set; }

        [DisplayName("Upload Profile Picture")]
        public string ImgPath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public virtual Profile Profiles { get; set; }
    }
}