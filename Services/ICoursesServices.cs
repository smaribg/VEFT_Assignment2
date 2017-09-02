using System;
using System.Collections.Generic;
using CoursesApi.Models.DTOs;

namespace CoursesApi.Services
{
    public interface ICoursesServices
    {
        IEnumerable<CourseDTO> GetCoursesBySemester(string semester);

        CourseDetailsDTO GetCourseById(int ID);
    }
}