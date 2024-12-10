using Student_Courses.Model;
using Student_Courses.Interface;
using Student_Courses.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Student_Courses.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Student getStudentByID(int id)
        {
            var student = _context.Student
                .Include(s => s.classes)  // Include related classes
                .FirstOrDefault(s => s.Id == id);

            return student; 
        }

        public async Task<int> addStudent(StudentDTO student)
        {
            // Check if student with the same email already exists
            var existingStudent = await _context.Student
                .FirstOrDefaultAsync(s => s.EmailId == student.EmailId);

            if (existingStudent != null)
            {
                // Optionally return a specific error message or throw exception
                return -1; // indicates email already exists
            }

            // Create the student object
            var dto = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                PhoneNumber = student.PhoneNumber,
                EmailId = student.EmailId
            };

            // Add the student to the database
            _context.Student.Add(dto);
            await _context.SaveChangesAsync();

            // Assign classes to the student
            if (student.ClassIds != null && student.ClassIds.Any())
            {
                var classes = await _context.Classes
                    .Where(c => student.ClassIds.Contains(c.Id))
                    .ToListAsync();

                foreach (var classItem in classes)
                {
                    dto?.classes?.Add(classItem);  // Add the classes to the student's collection
                }

                await _context.SaveChangesAsync();  // Save changes to update the relationship
            }

            return dto.Id; // return the new student's Id
        }

        public async Task<bool> deleteStudent(StudentDTO studentDto)
        {
            // Find the student by EmailId (or PhoneNumber)
            var student = await _context.Student
                .Include(s => s.classes)  // Include related classes (if you need to remove relationships)
                .FirstOrDefaultAsync(s => s.EmailId == studentDto.EmailId);  // Use EmailId for lookup

            // If the student does not exist, return false
            if (student == null)
            {
                return false;
            }

            // Remove the student from the database
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return true;
        }


        // Update student details with classes
        public async Task<string> updateStudentDetails(StudentDTO student)
        {
            // Find the student by EmailId (or PhoneNumber)
            var existingStudent = await _context.Student
                .Include(s => s.classes)  // Include related classes
                .FirstOrDefaultAsync(s => s.EmailId == student.EmailId);  // Using EmailId for lookup

            if (existingStudent == null)
            {
                return "Student not found"; // Or throw an exception
            }

            // Update basic student details
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.EmailId = student.EmailId;
            existingStudent.PhoneNumber = student.PhoneNumber;

            // Clear existing classes before assigning new ones
            existingStudent.classes.Clear();

            // Assign new classes if any
            if (student.ClassIds != null && student.ClassIds.Any())
            {
                var classes = await _context.Classes
                    .Where(c => student.ClassIds.Contains(c.Id))
                    .ToListAsync();

                foreach (var classItem in classes)
                {
                    existingStudent.classes.Add(classItem);  // Add the classes to the student's collection
                }
            }

            _context.Student.Update(existingStudent);
            await _context.SaveChangesAsync();

            return "Updated the Student Details";
        }


        // Get all students with their classes
        public List<Student> getAll()
        {
            return _context.Student
                .Include(s => s.classes)  // Include related classes
                .ToList();
        }

    }
}
