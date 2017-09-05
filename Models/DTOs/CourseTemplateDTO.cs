namespace CoursesApi.Models.DTOs
{
    public class CourseTemplateDTO
    {
        /// <summary>
        /// The name of the course. Example value: Web services
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The CourseID of the course. Example value: T-514-VEFT
        /// </summary>
        public string CourseID { get; set; }
    }
}