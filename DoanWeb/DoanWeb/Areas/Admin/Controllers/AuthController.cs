﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoanWeb.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Admin/Auth
        public ActionResult SignIn()
        {
            return RedirectToAction("SignIn", "User");
        }
    }
}