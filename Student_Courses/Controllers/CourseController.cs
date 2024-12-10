using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Courses.DTOs;
using Student_Courses.Interface;

namespace Student_Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetCourseById")]
        public IActionResult getById(int id)
        {
            var course = _courseService.GetCourseById(id);
            return Ok(course);
        }

        [HttpGet("GetAllCourses")]
        public IActionResult getAll()
        {
            var list = _courseService.getAll();
            return Ok(list);
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> addCourse(CourseDTO course)
        {
            var newCourse = await _courseService.AddCourseRecord(course);
            return Ok(newCourse);
        }

        [HttpPut("UpdateCourseDetails")]
        public async Task<IActionResult> updateCourseDetails(CourseDTO course)
        {
            var updated = await _courseService.UpdateCourseDetails(course);
            return Ok(updated);
        }

        [HttpDelete("DeleteCourse")]
        public async Task<IActionResult> deleteCourse(CourseDTO course)
        {
            var courses = await _courseService.DeleteCourse(course);
            return Ok(courses);
        }


    }
}
