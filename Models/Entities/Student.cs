namespace CoursesApi.Models.Entities
{
    /// <summary>
    /// A student
    /// </summary>
    public class Student
    {
        /// <summary>
        /// The ID of the student in the database. Example value: 4
        /// </summary>
        public int ID { get; set; }

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