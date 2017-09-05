namespace CoursesApi.Models.DTOs
{
    public class StudentDTO
    {
        /// <summary>
        /// The Social Security Number of the student. Example value: 123456-0011
        /// </summary>
        public string SSN { get; set;}
        
        /// <summary>
        /// The name of the student. Example value: Jónatan
        /// </summary>
        public string Name { get; set; }
    }
}