using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace DejtingApp.Models
{
    public class ProfilePageViewModels
    {
        public List<Profile> Profiles { get; set; }
        public List<Message> Messages { get; set; }
        public List<Friend> Friends { get; set; }
        public List<ProfileView> ProfileViews { get; set; }
        public List<Interest> Interests { get; set; }
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

    public class EditViewModel
    {
        public int ProfileId { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public DateTime Födelseår { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public List<Interest> Interests { get; set; }

    }

    public class ViewsListViewModel
    {
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }

    }

    /*public class EditViewModel
    {
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string MyProperty { get; set; }
        public DateTime Födelseår { get; set; }
        public string Description { get; set; }
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImgPath { get; set; }
        public int ProfileId { get; set; }


    }*/
}