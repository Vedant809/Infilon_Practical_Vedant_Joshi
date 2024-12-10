using Student_Courses.DTOs;
using Student_Courses.Model;

namespace Student_Courses.Interface
{
    public interface IStudentService
    {
        public Student GetStudentById(int id);
        public Task<int> AddStudentRecord(StudentDTO student);

        public Task<bool> DeleteStudent(StudentDTO student);
        public Task<string> UpdateStudentDetails(StudentDTO student);
        public List<Student> getAll();

    }
}
