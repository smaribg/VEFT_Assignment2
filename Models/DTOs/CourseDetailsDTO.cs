using System;
using System.Collections.Generic;

namespace CoursesApi.Models.DTOs
{
    public class CourseDetailsDTO
    {
        public int ID {get; set;}
        
        public string Name { get; set; }
        
        public string  CourseID { get; set; }

        public string Semester { get; set; }

        public DateTime StartDate {get; set;}

        public DateTime EndDate { get; set;}

        public List<StudentDTO> Students { get; set; }
    }
}