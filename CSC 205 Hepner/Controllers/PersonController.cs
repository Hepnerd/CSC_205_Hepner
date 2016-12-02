using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using CSC_205_Hepner.Models;



namespace CSC_205_Hepner.Controllers
{
    public class PersonController : Controller
    {

        List<Person> people;

        public PersonController()
        {
            people = new List<Person>
            {
                new Person() { id=1, firstname="Jean" , middlename="E" , lastname="Madeira" , cell="4125551122" , relationship="mom" , familyId=0 },
                new Person() { id=2, firstname="Nick" , middlename="A" , lastname="Madeira" , cell="4125559988" , relationship="son" , familyId=0 },
                new Person() { id=3, firstname="John" , middlename="M" , lastname="Madeira" , cell="4125551234" , relationship="son" , familyId=0 },
                new Person() { id=4, firstname="Chris" , middlename="T" , lastname="Madeira" , cell="4125556758" , relationship="son" , familyId=0 },
                new Person() { id=5, firstname="Jimmy" , middlename="J" , lastname="Johns" , cell="6075556758" , relationship="dad" , familyId=1 },
                new Person() { id=6, firstname="Stacey" , middlename="H" , lastname="Johns" , cell="6075556757" , relationship="mom" , familyId=1 },
                new Person() { id=7, firstname="Ian" , middlename="F" , lastname="Johns" , cell="6075552257" , relationship="son" , familyId=1 },
                new Person() { id=8, firstname="Avery" , middlename="K" , lastname="Johns" , cell="6075534757" , relationship="daughter" , familyId=1 },
                new Person() { id=9, firstname="Roy" , middlename="F" , lastname="Ellis" , cell="9035534757" , relationship="dad" , familyId=2 },
                new Person() { id=10, firstname="Michelle" , middlename="" , lastname="Ellis" , cell="9035531947" , relationship="mom" , familyId=2 },
                new Person() { id=11, firstname="Bernie" , middlename="S" , lastname="Braddock" , cell="8145534757" , relationship="mom" , familyId=3 },
                new Person() { id=12, firstname="Mark" , middlename="P" , lastname="Anderson" , cell="3025534757" , relationship="son" , familyId=3 }
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
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["peopleList"] == null)
            {
                Session["peopleList"] = people;
            }
        }

        // GET: Person
        public ActionResult Index()
        {
            var p = (List<Person>)Session["peopleList"];
            return View(p);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            // Get the list of people from the session
            var pList = (List<Person>)Session["peopleList"];

            // Get the person with the passed in ID
            var p = pList[id];

            // Return the person data to the view
            return View(p);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Person newPerson = new Person()
                {
                    id = 99,
                    firstname = collection["firstname"],
                    middlename = collection["middlename"],
                    lastname = collection["lastname"],
                    cell = collection["cell"],
                    relationship = collection["relationship"],
                    familyId = int.Parse(collection["familyId"]
                    )
                };

                // Add the person to the list
                people = (List<Person>)Session["peopleList"];
                people.Add(newPerson);

                // Save the list to the session
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
            return View();
        }

        // POST: Person/Edit/5
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

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
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
