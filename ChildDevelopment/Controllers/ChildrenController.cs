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
        DateTime read_write,
        string patron_name,
        string patron_password
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

            int childId = child.GetId();
            Patron foundPatron = Patron.FindByName(patron_name, patron_password);
            foundPatron.EditByChildId(childId);


            for (int i=1;i<=14;i++)
            {
              if (events[i-1]!=DateTime.MinValue)
              {
                int eventTime = (int)Math.Round(((events[i-1] - birth_date).TotalDays)/7);
                child.AddChildEvents(i,eventTime);
              }
            }
            List<int> childEvents= child.GetEvents();
            List<int> childDates = child.GetDates();
            List<int> childAverages = Event.GetAverages();
            string result = "[";
            for (int i=0; i<childEvents.Count; i+=1)
            {
                result+= "[stringArray[" + (childEvents[i]).ToString() + "]," + childDates[i].ToString() + "," + childAverages[i].ToString() +"]";
                if (i<childEvents.Count-1)
                {
                    result+= ",";
                }
            }
            result += "]";

            return View("Index",result);
        }

        [HttpGet("/children/edit/{id}")]
          public ActionResult Edit(int id)
          {
              Dictionary<string,object> model = new Dictionary <string,object>();
              Child child = Child.Find(id);
              List<int> childEvents = child.GetEvents();
              model.Add("child", child);
              model.Add("childEvents", childEvents);
              return View(model);
          }

           [HttpPost("/children/{id}/edit")]
          public ActionResult Update(string name, bool gender, int weight, int height, DateTime birthdate, bool breastfeeding, int id)
          {
              Child child = Child.Find(id);
              child.Edit(name, gender, weight, height, birthdate, breastfeeding);
              return View("Index", child);
          }

    }
}
