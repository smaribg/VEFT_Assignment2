using System;
using System.Linq;
using System.Collections.Generic;
using CoursesApi.Models.DTOs;

namespace CoursesApi.Repo
{
    public class CoursesRepo : ICoursesRepo
    {
        private readonly AppDataContext _db;

        public CoursesRepo(AppDataContext db){
            _db = db;
        }

        public IEnumerable<CourseDTO> GetCourses()
        {
            var courses = (from c in _db.Courses
                            select new CourseDTO
                            {
                                ID = c.ID,
                                CourseID = c.CourseID,
                                Semester = c.Semester

                            }).ToList();
            return courses;
        }

        public CourseDetailsDTO GetCourseById(int ID)
        {
            var course = (from c in _db.Courses
                            where c.ID == ID
                            select new CourseDetailsDTO
                            {
                                ID = c.ID,
                                CourseID = c.CourseID,
                                Semester = c.Semester,
                                StartDate = c.StartDate,
                                EndDate = c.EndDate
                                
                            }).SingleOrDefault();
            return course;
        }

        public CourseTemplateDTO GetCourseTemplateByCourseId(string courseID)
        {
            var cTemplate = (from c in _db.CourseTemplates
                                where c.CourseId == courseID
                                select new CourseTemplateDTO
                                {
                                    Name = c.Name,
                                    CourseID = c.CourseId
                                }).SingleOrDefault();
            return cTemplate;
        }

        public IEnumerable<StudentDTO> GetStudentsInCourse(int CourseId)
        {
            var students = (from s in _db.Students
                            join en in _db.Enrollments on s.ID equals en.StudentId
                            where en.CourseId == CourseId
                            select new StudentDTO
                            {
                                Name = s.Name,
                                SSN = s.SSN
                            }).ToList();
            return students;
        }
    }
}