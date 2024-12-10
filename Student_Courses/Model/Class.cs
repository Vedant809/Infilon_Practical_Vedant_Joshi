using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Student_Courses.Model
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [JsonIgnore]
        public ICollection<Student> student { get; set; } = new List<Student>();
    }
}
