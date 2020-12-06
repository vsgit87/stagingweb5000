using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcapp.Models;

namespace mvcapp.Controllers
{
    public class HomeController : Controller
    {
        MemoryDataSet newdtset;
        // Remember the Controller constructor is called for every request
        // This is because each HTTP request is stateless
        public HomeController()
        {
            System.Diagnostics.Trace.TraceInformation("Invoking the controller");
            newdtset = new MemoryDataSet();
        }
        public ActionResult Index()
        {
            var model = newdtset.GetCourses();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            var model=newdtset.GetCourseDetails(id);
            if (model==null)
            {
                return View("DetailsError");
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course viewobj)
        {
            if (ModelState.IsValid)
            {
                newdtset.CreateCourse(viewobj);
                
                return RedirectToAction("Details", new { id = viewobj.Id });
            }
            
            return View(viewobj);
        }
    
    public ActionResult Edit(int id)
        {
            var model = newdtset.GetCourseDetails(id);
            if (model == null)
            {
                return View("DetailsError");
            }
            return View(model);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course viewobj)
        {
            if (ModelState.IsValid)
            {
                newdtset.EditCourse(viewobj);
                // Here we want to execure the Details method again on the controller so that this action is performed after the edit
                return RedirectToAction("Details", new { id = viewobj.Id });
            }
            // If the model state is not valid, then the same edit page will be returned to the user
            return View(viewobj);
        }
    }
}