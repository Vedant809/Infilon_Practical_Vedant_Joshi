using Student_Courses.DTOs;
using Student_Courses.Interface;
using Student_Courses.Model;
using Student_Courses.Repository;

namespace Student_Courses.Services
{
    public class CourseService:ICourseService
    {
        private readonly ICoursesRepository _courseRepo;

        public CourseService(ICoursesRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public Class GetCourseById(int id)
        {
            var course = _courseRepo.getCourseByID(id);
            return course;
        }
        public async Task<int> AddCourseRecord(CourseDTO course)
        {
            var courses = await _courseRepo.addCourse(course);
            return courses;
        }

        public async Task<bool> DeleteCourse(CourseDTO course)
        {
            var isDeleted = await _courseRepo.deleteCourse(course);
            return isDeleted;
        }
        public async Task<string> UpdateCourseDetails(CourseDTO course)
        {
            var update = await _courseRepo.updateCourseDetails(course);
            return update;
        }
        public List<Class> getAll()
        {
            var courseList = _courseRepo.getAll();
            return courseList;
        }
    }
}
