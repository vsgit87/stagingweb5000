using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcapp.Models
{
    public class MemoryDataSet
    {
               

        public IEnumerable<Course> GetCourses()
        {
            List<Course> pset;
            pset = (List<Course>)System.Web.HttpContext.Current.Application["dtset"];
            return pset;
        }

        public Course GetCourseDetails(int id)
        {
            List<Course> pset;
            pset = (List<Course>)System.Web.HttpContext.Current.Application["dtset"];
            return pset.FirstOrDefault(c => c.Id == id);
        }

        public void CreateCourse(Course courseobj)
        {
            List<Course> pset;
            pset = (List<Course>)System.Web.HttpContext.Current.Application["dtset"];
            pset.Add(courseobj);
        }
        public void EditCourse(Course courseobj)
        {

            Course pobj=GetCourseDetails(courseobj.Id);
            if(pobj!=null)
            {
                pobj.Description = courseobj.Description;
            }
        }
    }
}