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
        /// <summary>
        ///when we create a new contact it add in the create function and then in this function it enter
        ///in list and then add in the Data base Entity
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<PersonViewModel> l = new List<PersonViewModel>();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var v = db.Person.ToList();
            foreach(var i in v) // Var type variable to store the list of contacts
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
        /// <summary>
        /// Show the details of list of contacts of those user whic are login
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            List<PersonViewModel> l = new List<PersonViewModel>();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var v = db.Person.ToList();
            foreach (var i in v)
            {
                if (i.PersonId == id) // check the Id of login person to show only those contacts that are create by this login
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
        /// <summary>
        /// Create the new contacts and then add the in to the entity and call the index function
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
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
                p.AddedBy = User.Identity.GetUserId();
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
        /// <summary>
        /// This function  edit the details of the create persons and update their information
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, PersonViewModel collection)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();
                var p = db.Person.Where(x=>x.PersonId==id).First(); //Condition to check the Id of specific person to edit only his/her details

                
                
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
            
            return View();
        }

        // POST: Person/Delete/5
        /// <summary>
        /// Delete the person and then add the new one
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, PersonViewModel collection)
        {
            try
            {
                PhoneBookDbEntities db = new PhoneBookDbEntities();

                var contacts = db.Contacts.Where(x => x.PersonId == id); //Condition to check the Id of specific person to edit only his/her details
                foreach (var i in contacts)
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
                //return Content("delete");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
