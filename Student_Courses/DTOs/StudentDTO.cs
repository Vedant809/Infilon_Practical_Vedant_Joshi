using System.ComponentModel.DataAnnotations;

namespace Student_Courses.DTOs
{
    public class StudentDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailId { get; set; }
        public List<int> ClassIds { get; set; }
    }
}
