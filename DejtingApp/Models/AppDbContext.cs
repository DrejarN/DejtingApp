﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DejtingApp.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public AppDbContext() : base(ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString) { }
    }

}