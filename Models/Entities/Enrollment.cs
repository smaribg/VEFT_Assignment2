namespace CoursesApi.Models.Entities
{
    /// <summary>
    /// A class representation of a student enrolled in a course
    /// </summary>
    public class Enrollment
    {
        /// <summary>
        /// The ID of the enrollment in the database. Example value: 4
        /// </summary>
        /// <returns></returns>
        public int ID { get; set;}

        /// <summary>
        /// The ID of the course in the database. Example value: 4
        /// </summary>
        /// <returns></returns>
        public int CourseId { get; set; }

        /// <summary>
        /// The ID of the student in the database. Example value: 4
        /// </summary>
        /// <returns></returns>
        public int StudentId { get; set; }
    }
}