using Student_Courses.DTOs;
using Student_Courses.Model;

namespace Student_Courses.Interface
{
    public interface ICourseService
    {
        public Class GetCourseById(int id);
        public Task<int> AddCourseRecord(CourseDTO course);

        public Task<bool> DeleteCourse(CourseDTO course);
        public Task<string> UpdateCourseDetails(CourseDTO course);
        public List<Class> getAll();

    }
}
