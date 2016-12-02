using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using CSC_205_Hepner.Models;


namespace CSC205_Madeira.Controllers
{
    public class CarsController : Controller
    {
        List<Car> cars;

        public CarsController()
        {
            cars = new List<Car>
            {
                new Car() { id=0, make = "Acura", model = "TL", color = "red", year = 2004 },
                new Car() { id=0, make = "Honda", model = "Civic", color = "blue", year = 2014 },
            };
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["carList"] == null)
            {
                Session["carList"] = cars;
            }
        }

        // GET: Cars
        public ActionResult Index()
        {
            var c = (List<Car>)Session["carList"];

            return View(c);
        }

        // GET: Cars/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Car newCar = new Car()
                {
                    id = 3,
                    make = collection["make"],
                    model = collection["model"],
                    color = collection["color"],
                    year = int.Parse(collection["year"])
                };

                cars = (List<Car>)Session["carList"];
                cars.Add(newCar);

                Session["carList"] = cars;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cars/Edit/5
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

        // GET: Cars/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cars/Delete/5
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
