namespace WagerWatcher.Services
{
    public class RaceCourseService
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
