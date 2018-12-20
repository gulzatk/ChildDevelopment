using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ChildDevelopment.Models;
using System;

namespace ChildDevelopment.Controllers
{
    public class PatronController : Controller
    {

        [HttpGet("/patrons/login")]
        public ActionResult Login(string name, string password, int childId)
        {
        Patron newPatron = Patron.FindByName(name, password, childId);
        return View(newPatron);
        }

        [HttpGet("/patrons/account")]
        public ActionResult Account()
        {
            return View();
        }

         [HttpGet("/patrons/exist")]
        public ActionResult Exist()
        {
            return View();
        }
        
        [HttpPost("/patrons/login")]
        public ActionResult New(string name, string password, int childId)
        {
            List<Patron> patronList = Patron.GetAll();
            Patron newPatron = new Patron(name, password, childId);
            if (!Patron.IsUnique(name))
            {
                newPatron.Save();
                return View(newPatron);
            }
            else
            {
                return RedirectToAction("Exist");
            }

            return View(newPatron);
        }
    }
}