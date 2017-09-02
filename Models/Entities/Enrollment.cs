namespace CoursesApi.Models.Entities
{
    public class Enrollment
    {
        public int ID { get; set;}
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }
}