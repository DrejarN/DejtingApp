﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DejtingApp.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Förnamn { get; set; }
    }
}