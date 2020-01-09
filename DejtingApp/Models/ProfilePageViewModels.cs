using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace DejtingApp.Models
{
    public class ProfilePageViewModels
    {
        public List<Profile> Profiles { get; set; }
        public List<Message> Messages { get; set; }
        public List<Friend> Friends { get; set; }
        public List<ProfileView> ProfileViews { get; set; }
    }

    public class FriendListViewModel
    {
        public int ProfileId { get; set; }
        public string ImagePath { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Category> Categories { get; set; }
    }

    public class ViewsListViewModel
    {
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }

    }
}