namespace CoursesApi.Models.DTOs
{
    public class CourseLiteDTO
    {
        /// <summary>
        /// The ID or index of the course in the database. Example value: 2
        /// </summary>        
        public int ID {get; set;}

        /// <summary>
        /// The name of the course. Example value: Forritun
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The CourseID of the course. Example value: T-514-VEFT
        /// </summary>
        public string  CourseID { get; set; }

        /// <summary>
        /// The semester of this course instance. Example value: 20173
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// The number of students enrolled in the course. Example value: 20
        /// </summary>
        public int NumberOfStudents { get; set; }
    }
}