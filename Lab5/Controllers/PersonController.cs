using Lab5.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            List<PersonViewModel> l = new List<PersonViewModel>();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var v = db.Person.ToList();
            foreach(var i in v)
            {
                    if (User.Identity.GetUserId() == i.AddedBy)
                    {
                        PersonViewModel p = new PersonViewModel();
                        p.PersonId = i.PersonId;
                        p.FirstName = i.FirstName;
                        p.MiddleName = i.MiddleName;
                        p.LastName = i.LastName;
                        p.DateOfBirth = Convert.ToDateTime(i.DateOfBirth);
                        p.AddedOn = i.AddedOn;
                        p.HomeAddress = i.HomeAddress;
                        p.HomeCity = i.HomeCity;
                        p.FaceBookAccountId = i.FaceBookAccountId;
                        p.LinkedInId = i.LinkedInId;
                        p.UpdateOn = Convert.ToDateTime(i.UpdateOn);
                        p.ImagePath = i.ImagePath;
                        p.TwitterId = i.TwitterId;
                        p.EmailId = i.EmailId;
                        l.Add(p);
                    }
                
                
                

            }
            return View(l);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            List<PersonViewModel> l = new List<PersonViewModel>();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var v = db.Person.ToList();
            foreach (var i in v)
            {
                if (i.PersonId == id)
                {
                    PersonViewModel p = new PersonViewModel();
                    p.PersonId = i.PersonId;
                    p.FirstName = i.FirstName;
                    p.MiddleName = i.MiddleName;
                    p.LastName = i.LastName;
                    p.DateOfBirth = Convert.ToDateTime(i.DateOfBirth);
                    p.AddedOn = i.AddedOn;
                    p.HomeAddress = i.HomeAddress;
                    p.HomeCity = i.HomeCity;
                    p.FaceBookAccountId = i.FaceBookAccountId;
                    p.LinkedInId = i.LinkedInId;
                    p.UpdateOn = Convert.ToDateTime(i.UpdateOn);
                    p.ImagePath = i.ImagePath;
                    p.TwitterId = i.TwitterId;
                    p.EmailId = i.EmailId;
                    l.Add(p);
                }

            }
            return View(l);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();

                Person p = new Person();
                p.FirstName = collection.FirstName;
                p.MiddleName = collection.MiddleName;
                p.LastName = collection.LastName;
                p.DateOfBirth = collection.DateOfBirth;
               // p.AddedBy = User.Identity.GetUserId();
                p.AddedOn = collection.AddedOn;
                p.HomeAddress = collection.HomeAddress;
                p.HomeCity = collection.HomeCity;
                p.FaceBookAccountId = collection.FaceBookAccountId;
                p.LinkedInId = collection.LinkedInId;
                p.UpdateOn = collection.UpdateOn;
                p.ImagePath = collection.ImagePath;
                p.TwitterId = collection.TwitterId;
                p.EmailId = collection.EmailId;
                db.Person.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonViewModel collection)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                var p = db.Person.Where(x=>x.PersonId==id).First();

                
                
                p.FirstName = collection.FirstName;
                p.MiddleName = collection.MiddleName;
                p.LastName = collection.LastName;
                p.DateOfBirth = Convert.ToDateTime(collection.DateOfBirth);
                p.AddedOn = collection.AddedOn;
                p.HomeAddress = collection.HomeAddress;
                p.HomeCity = collection.HomeCity;
                p.FaceBookAccountId = collection.FaceBookAccountId;
                p.LinkedInId = collection.LinkedInId;
                p.UpdateOn = Convert.ToDateTime(collection.UpdateOn);
                p.ImagePath = collection.ImagePath;
                p.TwitterId = collection.TwitterId;
                p.EmailId = collection.EmailId;
                db.SaveChanges();
                
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            PhoneBookDbEntities db = new PhoneBookDbEntities();

            var contacts = db.Contacts.Where(x => x.PersonId == id);
            foreach(var i in contacts)
            {
                Contact c = new Contact()
                {
                    ContactId = i.ContactId
                };
                db.Entry(c).State = System.Data.Entity.EntityState.Deleted;
            }
            db.SaveChanges();
            //var person = db.Person.Where(x => x.PersonId == id).First();
            Person p = new Person()
            {
                PersonId = id
            };
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Content("delete");
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
