using System;
using System.Collections.Generic;
using CoursesApi.Models.DTOs;
using CoursesApi.Models.ViewModels;

namespace CoursesApi.Services
{
    public interface ICoursesServices
    {
        IEnumerable<CourseLiteDTO> GetCoursesBySemester(string semester);

        CourseDTO GetCourseById(int ID);

        bool AddCourse(CourseViewModel course);

        bool UpdateCourse(CourseUpdateViewModel course, int courseId);

        bool DeleteCourse(int courseId);

        IEnumerable<StudentDTO> GetStudentsInCourse(int courseId);

        void AddStudentToCourse(StudentViewModel student, int courseId);

        IEnumerable<StudentDTO> GetWaitingListForCourse(int courseId);

        void AddStudentToWaitList(StudentViewModel student, int courseId);

        void DeleteStudentFromWaitingList(int courseId, string studentSSN);

    }
}