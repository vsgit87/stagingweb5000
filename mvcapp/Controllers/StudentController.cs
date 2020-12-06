using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcapp.Models;

namespace mvcapp.Controllers
{
    public class StudentController : Controller
    {
        StudentMemoryDataSet newdtset;
        public StudentController()
        {
            newdtset = new StudentMemoryDataSet();
        }
        public ActionResult Index()
        {
            var model=newdtset.GetStudents();
            return View(model);
        }
    }
}