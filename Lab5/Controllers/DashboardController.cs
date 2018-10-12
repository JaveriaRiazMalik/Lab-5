using Lab5.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class DashboardController : Controller
    {
        public List<DateTime> BirthDays()
        {

            List<DateTime> daterange = new List<DateTime>();
            for (int i = 1; i < 11; i++)
            {
                DateTime t = DateTime.Now;
                daterange.Add(t.AddDays(i).Date);



            }
            DateTime today = DateTime.Now;
            daterange.Add(today.Date);
            return daterange;

        }

        public List<DateTime> LastSevenDays()
        {

            List<DateTime> daterange = new List<DateTime>();
            for (int i = -6; i < 0; i++)
            {
                DateTime t = DateTime.Now;
                daterange.Add(t.AddDays(i).Date);


            }
            DateTime today = DateTime.Now;
            daterange.Add(today.Date);

            return daterange;
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            PhoneBookDbEntities ent = new PhoneBookDbEntities();
            var db = ent.People;
            int i = 0;
            

            foreach (var a in db)
            {
                if (a.AddedBy == User.Identity.GetUserId())
                {
                    i++;
                }

            }
            return Content("Persons are -->" + i);
        }
        public ActionResult BirthdayLists()
        {
            List<DateTime> birthdaydays = BirthDays();


            List<PersonViewModel> birthdays = new List<PersonViewModel>();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var persons = db.People.ToList();


            foreach (var a in persons)
            {
                if (a.AddedBy == User.Identity.GetUserId())
                {
                    foreach (DateTime j in birthdaydays)
                    {
                        if (j.Day == Convert.ToDateTime(a.DateOfBirth).Day && j.Month == Convert.ToDateTime(a.DateOfBirth).Month)
                        {
                            PersonViewModel p = new PersonViewModel()
                            {
                                DateOfBirth = Convert.ToDateTime(a.DateOfBirth),
                                FirstName = a.FirstName,
                                MiddleName = a.MiddleName,
                                LastName = a.LastName,
                                PersonId = a.PersonId,
                                EmailId = a.EmailId,
                                ImagePath = a.ImagePath,

                                AddedOn = a.AddedOn,
                                HomeAddress = a.HomeAddress,
                                HomeCity = a.HomeCity,
                                FaceBookAccountId = a.FaceBookAccountId,
                                LinkedInId = a.LinkedInId,
                                UpdateOn = Convert.ToDateTime(a.UpdateOn),
                                TwitterId = a.TwitterId,

                        };
                            birthdays.Add(p);
                        }
                    }
                }

            }
            return View(birthdays);
        }
        public ActionResult UpdatedLists()
        {
            List<DateTime> lastSevenDays = LastSevenDays();
            List<PersonViewModel> updatedPerson = new List<PersonViewModel>();
            PhoneBookDbEntities db = new PhoneBookDbEntities();
            var persons = db.People.ToList();


            foreach (var b in persons)
            {
                if (b.AddedBy == User.Identity.GetUserId())
                {
                    foreach (DateTime j in lastSevenDays)
                    {
                        if (j.Day == Convert.ToDateTime(b.UpdateOn).Day && j.Month == Convert.ToDateTime(b.UpdateOn).Month)
                        {

                            PersonViewModel p = new PersonViewModel
                            {

                                DateOfBirth = Convert.ToDateTime(b.DateOfBirth),
                                FirstName = b.FirstName,
                                MiddleName = b.MiddleName,
                                LastName = b.LastName,
                                PersonId = b.PersonId,
                                EmailId = b.EmailId,
                                ImagePath = b.ImagePath,

                                AddedOn = b.AddedOn,
                                HomeAddress = b.HomeAddress,
                                HomeCity = b.HomeCity,
                                FaceBookAccountId = b.FaceBookAccountId,
                                LinkedInId = b.LinkedInId,
                                UpdateOn = Convert.ToDateTime(b.UpdateOn),
                                TwitterId = b.TwitterId,
                            };
                            updatedPerson.Add(p);
                        }
                    }

                }
            }
            return View(updatedPerson);

        }
        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            PhoneBookDbEntities ent = new PhoneBookDbEntities();

            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
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

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
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
