using Microsoft.EntityFrameworkCore;
using Student_Courses.DTOs;
using Student_Courses.Interface;
using Student_Courses.Model;

namespace Student_Courses.Repository
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly AppDbContext _context;

        public CoursesRepository(AppDbContext context)
        {
            _context = context;
        }
        public Class getCourseByID(int id)
        {
            var course = _context.Classes.Include(x => x.student).FirstOrDefault(x => x.Id == id);
            return course;
        }
        public async Task<int> addCourse(CourseDTO course)
        {
            // Create a new Class entity from the provided CourseDTO
            Class dto = new Class()
            {
                Name = course.Name,
                Description = course.Description
            };


            // Add the class to the context
            _context.Classes.Add(dto);
            await _context.SaveChangesAsync();
            

            // Assign Students to the Class if StudentIds are provided
            if (course.StudentIds != null && course.StudentIds.Any())
            {
                var students = await _context.Student
                    .Where(s => course.StudentIds.Contains(s.Id)) // Filter students by provided IDs
                    .ToListAsync();

                // Check if any student IDs were invalid
                if (students.Count != course.StudentIds.Count)
                {
                    throw new Exception("Some Student IDs are invalid."); // Handle missing students
                }

                foreach (var student in students)
                {
                    dto?.student?.Add(student); // Add the students to the class's student collection
                }

                await _context.SaveChangesAsync(); // Save changes to update the relationship
            }

            return dto.Id; // Return the ID of the newly created class
        }

        // Delete a course
        public async Task<bool> deleteCourse(CourseDTO course)
        {
            // Find the class by Name (assuming it is unique; adjust if needed)
            var existingClass = await _context.Classes
                .Include(c => c.student)  // Include associated students
                .FirstOrDefaultAsync(c => c.Name == course.Name);

            if (existingClass == null)
            {
                return false; // Course not found
            }

            // Remove the class
            _context.Classes.Remove(existingClass);
            await _context.SaveChangesAsync();

            return true; // Deletion successful
        }

        // Update course details
        public async Task<string> updateCourseDetails(CourseDTO course)
        {
            Class dto = new Class()
            {
                Name = course.Name,
                Description = course.Description
            };

            _context.Classes.Update(dto);
            await _context.SaveChangesAsync();

            return "Updated the Class Details";
        }

        // Get all classes
        public List<Class> getAll()
        {
            var courseList = _context.Classes.ToList();
            return courseList;
        }

    }
}
