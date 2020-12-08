using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DoanWeb.Models;
using System.Net;
using System.Net.Mail;
using System.Web.Helpers;

namespace DoanWeb.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(string youremail,string yoursubject,string message)
        {
            WebMail.Send(youremail, yoursubject, message,null,null,null,true,null,null,null,null,null,null);
            ViewBag.msg = "Message sent successful!";
            return View();
        }
    }
}