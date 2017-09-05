namespace CoursesApi.Models.Entities
{
    /// <summary>
    /// A template of the course
    /// </summary>
    public class CourseTemplate
    {
        /// <summary>
        /// The ID or index of the course in the database. Example value: 2
        /// </summary>        
        public int ID { get; set;} 
        
        /// <summary>
        /// The name of the course. Example value: Web services
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        /// The CourseID of the course. Example value: T-514-VEFT
        /// </summary>

        public string CourseId { get; set; }
    }
}