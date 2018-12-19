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
            List<Child> children = Child.GetAll();
            return View(children);
        }

        [HttpGet("/children/new")]
        public ActionResult New()
        {   
            return View();
        }

    }
}