using Lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            List<ContactViewModel> l = new List<ContactViewModel>();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var v = db.Contacts.ToList();
            foreach (var i in v)
            {
       
                    ContactViewModel p = new ContactViewModel();
                    p.ContactId = i.ContactId;
                    p.ContactNumber = i.ContactNumber;
                    p.Type = i.Type;
                    p.PersonId = i.PersonId;
                    l.Add(p);
                
            }
            return View(l);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            List<ContactViewModel> l = new List<ContactViewModel>();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var v = db.Contacts;
            foreach (var i in v)
            {
                if (i.PersonId == id)
                {
                    ContactViewModel p = new ContactViewModel();
                    p.PersonId = i.PersonId;
                    p.ContactNumber = i.ContactNumber;
                    p.ContactId = i.ContactId;
                    p.Type = i.Type;
                    l.Add(p);
                }
            }
            return View(l);

        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(int id,ContactViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                PhoneBookDbEntities db = new PhoneBookDbEntities();

                Contact p = new Contact();
                p.ContactNumber = collection.ContactNumber;
                p.Type = collection.Type;
                p.PersonId = id;
                db.Contacts.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contact/Delete/5
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
