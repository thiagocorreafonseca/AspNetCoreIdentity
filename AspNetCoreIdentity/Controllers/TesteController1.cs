﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentity.Controllers
{
    public class TesteController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
