using System;

namespace CoursesApi.Models.Entities
{
    /// <summary>
    /// A class representation of a course
    /// </summary>
    public class Course
    {
        /// <summary>
        /// The ID or index of the course in the database. Example value: 2
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The CourseID of the course. Example value: T-514-VEFT
        /// </summary>
        public string CourseID { get; set; }

        /// <summary>
        /// The semester of this course instance. Example value: 20173
        /// </summary>
        public string Semester { get; set; }

        /// <summary>
        /// The date that the course starts. Example value: 2017-08-16T00:00:00
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///The date that the course starts. Example value: 2017-08-16T00:00:00
        /// </summary>
        public DateTime EndDate { set; get; }

    }
}