using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ChildDevelopment.Models;

namespace ChildDevelopment.Controllers
{
    public class PatronController : Controller
    {
        [HttpGet("/patrons/login")]
        public ActionResult Login(string name, string password)
        {
        Patron newPatron = Patron.FindByName(name, password);
        return View(newPatron);
        }

        [HttpGet("/patrons/account")]
        public ActionResult Account()
        {
            return View();
        }
        
        [HttpPost("/patrons/login")]
        public ActionResult New(string name, string password)
        {
            Patron newPatron = new Patron(name, password);
            newPatron.Save();
            return View(newPatron);
        } 


    }
}