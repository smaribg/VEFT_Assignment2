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

        bool AddStudentToCourse(int studentID, int courseId);

        IEnumerable<StudentDTO> GetWaitingListForCourse(int courseId);

        bool AddStudentToWaitList(int studentID, int courseId);

        int GetStudentId(string SSN);

        void DeleteStudentFromWaitingList(int courseId, string studentSSN);
        IEnumerable<StudentDTO> GetAllStudents();
        void RemoveStudentFromCourse(int courseId, string studentSSN);
    }
}