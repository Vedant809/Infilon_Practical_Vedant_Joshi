using System.ComponentModel.DataAnnotations;

namespace Student_Courses.DTOs
{
    public class CourseDTO
    {
        public List<int> StudentIds { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
