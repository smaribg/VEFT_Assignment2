namespace CoursesApi.Models.DTOs
{
    public class CourseDTO
    {
        public int ID {get; set;}

        public string Name { get; set; }
        
        public string  CourseID { get; set; }

        public string Semester { get; set; }

        public int NumberOfStudents { get; set; }
    }
}