using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DejtingApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> people { get; set; }

        public AppDbContext() : base("appdb") { }
    }

}