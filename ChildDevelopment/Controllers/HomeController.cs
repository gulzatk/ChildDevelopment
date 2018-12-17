using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ChildDevelopment.Models;

namespace ChildDevelopment.Controllers
{
    public class HomeController : Controller
    {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
    }
}
