using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSC_205_Hepner.Models;
using System.Web.Routing;



namespace CSC_205_Hepner.Controllers
{
    public class PersonController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["peopleList"] == null)
            {
                Session["peopleList"] = people;
            }
        }

        List<Person> people;

        public PersonController()
        {
            people = new List<Person>
            {
                new Person() { id=0, firstname = "Zack", middlename = "S", lastname = "Fisher", cell = "4125540408", relationship = "son", familyId = 0 },
                new Person() { id=1, firstname="Matt" , middlename="T" , lastname="Fisher" , cell="4120784623" , relationship="son" , familyId=0 },
                new Person() { id=2, firstname="Brian" , middlename="T" , lastname="Fisher" , cell="4126910926" , relationship="dad" , familyId=0 },
                new Person() { id=3, firstname="Laurie" , middlename="D" , lastname="Fisher" , cell="4120654028" , relationship="mom" , familyId=0 },
                new Person() { id=4, firstname="Ryan" , middlename="G" , lastname="Grimm" , cell="4408566917" , relationship="son" , familyId=5 },
                new Person() { id=5, firstname="Jimmy" , middlename="J" , lastname="Johns" , cell="6075556758" , relationship="dad" , familyId=1 },
                new Person() { id=6, firstname="Stacey" , middlename="H" , lastname="Johns" , cell="6075556757" , relationship="mom" , familyId=1 },
                new Person() { id=7, firstname="Ian" , middlename="F" , lastname="Johns" , cell="6075552257" , relationship="son" , familyId=1 },
                new Person() { id=8, firstname="Avery" , middlename="K" , lastname="Johns" , cell="6075534757" , relationship="daughter" , familyId=1 },
                new Person() { id=9, firstname="Roy" , middlename="F" , lastname="Ellis" , cell="9035534757" , relationship="dad" , familyId=2 },
                new Person() { id=10, firstname="Michelle" , middlename="" , lastname="Ellis" , cell="9035531947" , relationship="mom" , familyId=2 },
                new Person() { id=11, firstname="Bernie" , middlename="S" , lastname="Braddock" , cell="8145534757" , relationship="mom" , familyId=3 },

            };

        }

        /**
         * Session isn't available when the constructor is called.  Therefore, you need
         * to store the list in the Initialize method.
         * 
         * This method checks to see of the peopleList is already in Session.  If not,
         * it save the list to the session.  If it is already in session the method does nothing.
         * 
         * This StackOverflow entry talks about it:
         * http://stackoverflow.com/questions/18234355/get-an-existing-session-in-my-basecontroller-constructor
         * 
         */

        public ActionResult Index()
        {
            var people = Session["peopleList"] as List<Person>;
            return View(people);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var f = people[id];

            return View(f);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            var people = Session["peopleList"] as List<Person>;
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var people = Session["peopleList"] as List<Person>;

            try
            {
                Person person = new Person()
                {
                    id = people.Count(),
                    firstname = collection["firstname"],
                    middlename = collection["middlename"],
                    lastname = collection["lastname"],
                    cell = collection["cell"],
                    relationship = collection["relationship"],
                    familyId = int.Parse(collection["familyId"])
                };
                people = (List<Person>)Session["peopleList"];
                people.Add(person);

                //save family
                Session["peopleList"] = people;

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
            var f = people[id];

            return View(f);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var people = (List<Person>)Session["peopleList"];

                var f = people[id];

                Person person = new Person()
                {
                    id = people.Count(),
                    firstname = collection["firstname"],
                    middlename = collection["middlename"],
                    lastname = collection["lastname"],
                    cell = collection["cell"],
                    relationship = collection["relationship"],
                    familyId = int.Parse(collection["familyId"])
                };

                people.Where(x => x.id == id).First().firstname = collection["firstname"];
                people.Where(x => x.id == id).First().middlename = collection["middlename"];
                people.Where(x => x.id == id).First().lastname = collection["lastname"];
                people.Where(x => x.id == id).First().cell = collection["cell"];
                people.Where(x => x.id == id).First().relationship = collection["relationship"];
                people.Where(x => x.id == id).First().familyId = int.Parse(collection["familyID"]);

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
            var people = (List<Person>)Session["peopleList"];

            var f = people[id];

            Session["peopleList"] = people.Where(x => x.id != id).ToList();

            people = (List<Person>)Session["peopleList"];

            for (int x = id; x < people.Count(); x++)
            {
                if (people[x] != null)
                {
                    people[x].id = x;
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Person
        //public ActionResult Index()
        //{
        //    var p = (List<Person>)Session["peopleList"];
        //    return View(p);
        //}

        //// GET: Person/Details/5
        //public ActionResult Details(int id)
        //{
        //    // Get the list of people from the session
        //    var pList = (List<Person>)Session["peopleList"];

        //    // Get the person with the passed in ID
        //    var p = pList[id];

        //    // Return the person data to the view
        //    return View(p);
        //}

        //// GET: Person/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Person/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        Person newPerson = new Person()
        //        {
        //            id = 99,
        //            firstname = collection["firstname"],
        //            middlename = collection["middlename"],
        //            lastname = collection["lastname"],
        //            cell = collection["cell"],
        //            relationship = collection["relationship"],
        //            familyId = int.Parse(collection["familyId"]
        //            )
        //        };

        //        // Add the person to the list
        //        people = (List<Person>)Session["peopleList"];
        //        people.Add(newPerson);

        //        // Save the list to the session
        //        Session["peopleList"] = people;

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Person/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Person/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Person/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Person/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
