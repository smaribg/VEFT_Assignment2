using System;
using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Models.ViewModels
{
    public class CourseViewModel
    {
        /// <summary>
        /// The CourseID of the course. Example value: T-514-VEFT
        /// </summary>
        [Required]
        public string CourseId { get; set; }

        /// <summary>
        /// The semester of this course instance. Example value: 20173
        /// </summary>
        [Required]
        public string Semester { get; set; }

        /// <summary>
        /// The date the course starts. Example value: 2019-08-16T00:00:00
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The date the course ends. Example value: 2019-08-16T00:00:00
        /// </summary>       
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        ///The maximum number of students allowed to enroll in the course
        /// </summary>
        [Required]
        public int MaxStudents { set; get; }
    }
}