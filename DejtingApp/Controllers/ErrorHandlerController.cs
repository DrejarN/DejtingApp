﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DejtingApp.Controllers
{
    public class ErrorHandlerController : Controller
    {
        // GET: ErrorHandler
        public ActionResult GenericError()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}