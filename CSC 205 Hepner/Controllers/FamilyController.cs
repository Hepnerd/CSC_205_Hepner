using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSC_205_Hepner.Models;
using System.Web.Routing;

namespace CSC_205_Hepner.Controllers
{
    public class FamilyController : Controller
    {

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["familyList"] == null)
            {
                Session["familyList"] = families;
            }
        }

        List<Family> families;

        public FamilyController()
        {
            families = new List<Family>
            {
                new Family() { id=0, familyname = "Hepner", address1 = "2625 Middle Rd.", city = "Hampton Township", state = "PA", zip = "15116", homephone = "4124863823" },
                new Family() { id=1, familyname = "Yo Momma", address1 = "3200 College Ave", city = "Beaver Falls", state = "PA", zip = "15010", homephone = "7248461298" },
                new Family() { id=2, familyname = "President Trump", address1 = "1600 Penn Ave.", city = "Washington", state = "DC", zip = "20500", homephone = "1234567894" },
                new Family() { id=3, familyname = "Putin", address1 = "Kremlin Ave.", city = "Moscow", state = "RU", zip = "103073", homephone = "1234567985" }
            };


        }

        // GET: Family
        public ActionResult Index()
        {
            var families = Session["familylist"] as List<Family>;
            return View(families);
        }

        // GET: Family/Details/5
        public ActionResult Details(int id)
        {
            var f = families[id];

            return View(f);
        }

        // GET: Family/Create
        public ActionResult Create()
        {
            var families = Session["familyList"] as List<Family>;
            return View();
        }

        // POST: Family/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var families = Session["familyList"] as List<Family>;

            try
            {
                Family family = new Family()
                {
                    id = families.Count(),
                    familyname = collection["familyname"],
                    address1 = collection["address1"],
                    city = collection["city"],
                    state = collection["state"],
                    zip = collection["zip"],
                    homephone = collection["homephone"]
                };
                families = (List<Family>)Session["familyList"];
                families.Add(family);

                //save family
                Session["familyList"] = families;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Family/Edit/5
        public ActionResult Edit(int id)
        {
            var f = families[id];

            return View(f);
        }

        // POST: Family/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var families = (List<Family>)Session["familyList"];

                var f = families[id];

                Family family = new Family()
                {
                    id = f.id,
                    familyname = collection["familyname"],
                    address1 = collection["address1"],
                    city = collection["city"],
                    state = collection["state"],
                    zip = collection["zip"],
                    homephone = collection["homephone"]
                };

                families.Where(x => x.id == id).First().familyname = collection["familyname"];
                families.Where(x => x.id == id).First().address1 = collection["address1"];
                families.Where(x => x.id == id).First().city = collection["city"];
                families.Where(x => x.id == id).First().state = collection["state"];
                families.Where(x => x.id == id).First().zip = collection["zip"];
                families.Where(x => x.id == id).First().homephone = collection["homephone"];

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Family/Delete/5
        public ActionResult Delete(int id)
        {
            var families = (List<Family>)Session["familyList"];

            var f = families[id];

            Session["familyList"] = families.Where(x => x.id != id).ToList();

            families = (List<Family>)Session["familyList"];

            for (int x = id; x < families.Count(); x++)
            {
                if (families[x] != null)
                {
                    families[x].id = x;
                }
            }

            return RedirectToAction("Index");
        }

        //// POST: Family/Delete/5
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
