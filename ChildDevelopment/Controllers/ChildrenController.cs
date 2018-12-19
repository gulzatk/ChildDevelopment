using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ChildDevelopment.Models;
using System;

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
        [HttpPost("/children")]
        public ActionResult Index(
        string name,
        bool gender,
        int weight,
        int height,
        DateTime birth_date,
        bool breastfeeding,
        DateTime hold_head,
        DateTime roll_over,
        DateTime first_teeth,
        DateTime sit,
        DateTime crawl,
        DateTime walk,
        DateTime first_words,
        DateTime self_feeding,
        DateTime make_believe,
        DateTime two_word_sentence,
        DateTime potty_trained,
        DateTime dressed_self,
        DateTime tell_story,
        DateTime read_write
        )
        {
            DateTime[] events= new DateTime[]{hold_head,
            roll_over,
            first_teeth,
            sit,
            crawl,
            walk,
            first_words,
            self_feeding,
            make_believe,
            two_word_sentence,
            potty_trained,
            dressed_self,
            tell_story,
            read_write};
            Child child = new Child(name,gender,weight,height,birth_date,breastfeeding);
            child.Save();
            for (int i=1;i<=14;i++)
            {
              if (events[i-1]!=DateTime.MinValue)
              {
                child.AddChildEvents(i,events[i-1]);
              }
            }
            Console.WriteLine(roll_over-birth_date);
            return View();
        }

    }
}
