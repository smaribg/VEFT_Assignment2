using System;
using System.Collections.Generic;
using System.Linq;
using CoursesApi.Models.DTOs;
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

        public IEnumerable<CourseDTO> GetCoursesBySemester(string semester)
        {
            var courses = _repo.GetCourses();
            var coursesThisSemester = new List<CourseDTO>();


            foreach(CourseDTO c in courses){
                if(c.Semester == semester){
                    var courseTemplate = _repo.GetCourseTemplateByCourseId(c.CourseID);
                    var students = _repo.GetStudentsInCourse(c.ID);
                    Console.Write(c.CourseID);
                    if(courseTemplate == null){
                        Console.Write("HAHA");
                    }
                    c.Name = courseTemplate.Name;
                    c.NumberOfStudents = students.Count();
                    coursesThisSemester.Add(c);
                }
            }

            return coursesThisSemester;
        }

        public CourseDetailsDTO GetCourseById(int ID)
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
    }
}