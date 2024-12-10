using Student_Courses.Model;
using Student_Courses.DTOs;

namespace Student_Courses.Interface
{
    public interface IStudentRepository
    {
        public Student getStudentByID(int id);
        public Task<int> addStudent(StudentDTO student);

        public Task<bool> deleteStudent(StudentDTO student);
        public Task<string> updateStudentDetails(StudentDTO student);
        public List<Student> getAll();
    }
}
