using System;
using System.Collections.Generic;
using System.Linq;
using CoursesApi.Models.DTOs;
using CoursesApi.Models.ViewModels;
using CoursesApi.Repo;

namespace CoursesApi.Services
{
    public class CoursesServices : ICoursesServices
    {
        private readonly ICoursesRepo _repo;

        public CoursesServices(ICoursesRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<CourseLiteDTO> GetCoursesBySemester(string semester)
        {
            var courses = _repo.GetCourses();
            var coursesThisSemester = new List<CourseLiteDTO>();


            foreach(CourseLiteDTO c in courses){
                if(c.Semester == semester){
                    var courseTemplate = _repo.GetCourseTemplateByCourseId(c.CourseID);
                    var students = _repo.GetStudentsInCourse(c.ID);
                    c.Name = courseTemplate.Name;
                    c.NumberOfStudents = students.Count();
                    coursesThisSemester.Add(c);
                }
            }

            return coursesThisSemester;
        }

        public CourseDTO GetCourseById(int ID)
        {
            var course = _repo.GetCourseById(ID);

            if(course != null){
                var students = _repo.GetStudentsInCourse(ID);
                var courseTemplate = _repo.GetCourseTemplateByCourseId(course.CourseID);

                course.Name = courseTemplate.Name;
                course.Students = students.ToList();

                return course;
            }
            else{
                return null;
            }

        }

        public bool AddCourse(CourseViewModel course)
        {
            var cTemplate = _repo.GetCourseTemplateByCourseId(course.CourseId);
            if(cTemplate == null){
                return false;
            }

            return _repo.AddCourse(new CourseDTO
            {
                Name = cTemplate.Name,
                CourseID = course.CourseId,
                Semester = course.Semester,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                MaxStudents = course.MaxStudents
            });
            
        }

        public bool UpdateCourse(CourseUpdateViewModel course, int courseId)
        {
            return _repo.UpdateCourse(new CourseDTO
            {
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                MaxStudents = course.MaxStudents
            }
            ,courseId);
        }

        public bool DeleteCourse(int courseId)
        {
           return _repo.DeleteCourse(courseId);
        }

        public IEnumerable<StudentDTO> GetStudentsInCourse(int courseId)
        {
            return _repo.GetStudentsInCourse(courseId);
        }

        public bool AddStudentToCourse(StudentViewModel student, int courseId)
        {
            if(_repo.GetCourseById(courseId) == null)
                return false;
                
            return _repo.AddStudentToCourse(new StudentDTO
            {
                Name = student.Name,
                SSN = student.SSN
            },courseId);
        }

        public IEnumerable<StudentDTO> GetWaitingListForCourse(int courseId)
        {
            return _repo.GetWaitingListForCourse(courseId);
        }

        public bool AddStudentToWaitList(StudentViewModel student, int courseId)
        {
            if(_repo.GetCourseById(courseId) == null)
                return false;
                
            return _repo.AddStudentToWaitList(new StudentDTO
            {
                Name = student.Name,
                SSN = student.SSN
            },courseId);
        }

    }
}