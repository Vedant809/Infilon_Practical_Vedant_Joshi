using Student_Courses.DTOs;
using Student_Courses.Model;

namespace Student_Courses.Interface
{
    public interface ICoursesRepository
    {
        public Class getCourseByID(int id);
        public Task<int> addCourse(CourseDTO student);

        public Task<bool> deleteCourse(CourseDTO student);
        public Task<string> updateCourseDetails(CourseDTO student);
        public List<Class> getAll();
    }
}
