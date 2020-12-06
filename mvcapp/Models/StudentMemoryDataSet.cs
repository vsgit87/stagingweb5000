using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcapp.Models
{
    public class StudentMemoryDataSet
    {
        List<Student> dtset;
        public StudentMemoryDataSet()
        {
            dtset = new List<Student>()
            {
                new Student {Id=101,Name="User1", CourseId=1},
                new Student {Id=102,Name="User2", CourseId=2},
                new Student {Id=103,Name="User3", CourseId=3}
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return dtset;
        }
    }
}