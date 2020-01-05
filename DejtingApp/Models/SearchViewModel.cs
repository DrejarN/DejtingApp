using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DejtingApp.Models
{
    public class SearchViewModel
    {

        [Display(Name = "")]
        public string ImagePath { get; set; }

        [Display(Name = "Namn")]
        public string Förnamn { get; set; }

        [Display(Name = "Ålder")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Födelseår { get; set; }

        [Key]
        [Display(Name = "Add friend")]
        public int ProfileId { get; set; }








        //    public List<Profile> Profiles { get; set; }
        //    [Display(Name = "Search for user:")]
        //    public int ProfileId { get; set; }

        //    public IEnumerable<SelectListItem> Users
        //    {
        //    get
        //    {
        //        var allUsers = Profiles.Select(f => new SelectListItem
        //        {
        //            Value = "1",  //f.ProfileId.ToString(),
        //            Text = "Jamie" //f.Förnamn
        //        });

        //        return allUsers;

        //        get { return new SelectList(Profiles, "ProfileId", "Förnamn"); }

        //}
    }
}