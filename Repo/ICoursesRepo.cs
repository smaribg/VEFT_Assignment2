using System.Collections.Generic;
using CoursesApi.Models.DTOs;

namespace CoursesApi.Repo
{
    public interface ICoursesRepo
    {
        IEnumerable<CourseLiteDTO> GetCourses();

        CourseDTO GetCourseById(int ID);

        CourseTemplateDTO GetCourseTemplateByCourseId(string courseID);

        IEnumerable<StudentDTO> GetStudentsInCourse(int ID);

        bool AddCourse(CourseDTO course);

        bool UpdateCourse(CourseDTO course, int courseId);

        bool DeleteCourse(int courseId);

        bool AddStudentToCourse(StudentDTO student, int courseId);
    }
}