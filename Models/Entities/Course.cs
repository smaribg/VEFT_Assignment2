using System;

namespace CoursesApi.Models.Entities
{
    public class Course
    {
        public int ID { get; set; }

        public string CourseID { get; set; }

        public string Semester { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { set; get; }

    }
}