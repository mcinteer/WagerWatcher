using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WagerWatcher.Controller
{
    public class RaceCourseController
    {
        public static RaceCourse BuildCourse(string name, string address = "", int? phoneNumber = null)
        {
            var course = new RaceCourse()
                {
                    CourseName = name,
                    CourseAddress = address,
                    CoursePhone = phoneNumber
                };
            return course;
        }
    }
}
