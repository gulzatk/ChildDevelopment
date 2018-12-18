using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ChildDevelopment.Models;

namespace ChildDevelopment.Controllers
{
    public class ChildrenController : Controller
    {
        [HttpGet("/children")]
        public ActionResult Index()
        {
        return View();
        }

        [HttpGet("/children/account")]
        public ActionResult Account()
        {
        return View();
        }

        [HttpGet("/children/login")]
        public ActionResult Login()
        {
        return View();
        }

    }
}