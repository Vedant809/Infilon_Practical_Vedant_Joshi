using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Courses.DTOs;
using Student_Courses.Interface;

namespace Student_Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetStudentById")]
        public IActionResult getStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            return Ok(student);
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(StudentDTO student)
        {
            var newStudent = await _studentService.AddStudentRecord(student);
            return Ok(newStudent);
        }

        [HttpDelete("DeleteStudent")]

        public async Task<IActionResult> deleteStudentRecord(StudentDTO student)
        {
            var isDeleted = await _studentService.DeleteStudent(student);
            return Ok(isDeleted);
        }

        [HttpPut("UpdateStudentDetails")]

        public async Task<IActionResult> updateStudent(StudentDTO student)
        {
            var isAdded = await _studentService.UpdateStudentDetails(student);
            return Ok(isAdded);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> getAll()
        {
            var result = _studentService.getAll();
            return Ok(result);
        }

    }
}
