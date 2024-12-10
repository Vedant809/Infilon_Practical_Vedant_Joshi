using Student_Courses.Model;
using Student_Courses.DTOs;
using Student_Courses.Interface;
using Student_Courses.Repository;

namespace Student_Courses.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepo;

        public StudentService(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public Student GetStudentById(int id)
        {
            var student = _studentRepo.getStudentByID(id);
            return student;
        }
        public async Task<int> AddStudentRecord(StudentDTO student)
        {
            var id = await _studentRepo.addStudent(student);
            return id;
        }

        public async Task<bool> DeleteStudent(StudentDTO student)
        {
            bool isDeleted = await _studentRepo.deleteStudent(student);
            return isDeleted;
        }
        public async Task<string> UpdateStudentDetails(StudentDTO student)
        {
            var updated = await _studentRepo.updateStudentDetails(student);
            return updated;
        }
        public List<Student> getAll()
        {
            var studentList = _studentRepo.getAll();
            return studentList;
        }


    }
}
