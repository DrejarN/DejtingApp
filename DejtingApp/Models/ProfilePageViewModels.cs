using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace DejtingApp.Models
{
    public class ProfilePageViewModel
    {
        public List<Profile> Profiles { get; set; }
        public List<Message> Messages { get; set; }
    }

    public class ProfilePageIndexViewModel
    {
        public List<Profile> profiles { get; set; }
        public List<Message> Messages { get; set; }
        public List<Friend> Friends { get; set; }

    }
}