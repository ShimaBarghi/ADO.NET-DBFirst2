using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyContacts2.Models;


namespace MyContacts2.Controllers
{
    public class HomeController : Controller
    {
        EF_MyContactDBEntities db = new EF_MyContactDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Peopel1.ToList());
        }
        public ActionResult Detail(int id)
        {

            return View(db.Peopel1.Find(id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Peopel1 person)
        {
            db.Peopel1.Add(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {

            return View(db.Peopel1.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Peopel1 person)
        {
            var p = db.Peopel1.Find(person.ID);
            p.FullName = person.FullName;
            p.Email = person.Email;
            p.Website = person.Website;
            p.Mobail = person.Mobail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var p = db.Peopel1.Find(id);
            db.Peopel1.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}