using System.Collections.Generic;
using CoursesApi.Models.DTOs;

namespace CoursesApi.Repo
{
    public interface ICoursesRepo
    {
        IEnumerable<CourseDTO> GetCourses();

        CourseDetailsDTO GetCourseById(int ID);

        CourseTemplateDTO GetCourseTemplateByCourseId(string courseID);

        IEnumerable<StudentDTO> GetStudentsInCourse(int ID);
    }
}