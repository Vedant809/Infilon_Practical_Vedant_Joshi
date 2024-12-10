using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Student_Courses.Model
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string? EmailId { get; set; }
        [JsonIgnore]
        public ICollection<Class>? classes { get; set; } = new List<Class>();
    }
}
