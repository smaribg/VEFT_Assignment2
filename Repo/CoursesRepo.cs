using System;
using System.Linq;
using System.Collections.Generic;
using CoursesApi.Models.DTOs;
using CoursesApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Repo
{
    public class CoursesRepo : ICoursesRepo
    {
        private readonly AppDataContext _db;

        public CoursesRepo(AppDataContext db){
            _db = db;
        }

        public IEnumerable<CourseLiteDTO> GetCourses()
        {
            var courses = (from c in _db.Courses
                            select new CourseLiteDTO
                            {
                                ID = c.ID,
                                CourseID = c.CourseID,
                                Semester = c.Semester

                            }).ToList();
            return courses;
        }

        public CourseDTO GetCourseById(int ID)
        {
            var course = (from c in _db.Courses
                            where c.ID == ID
                            select new CourseDTO
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
            var course = _db.Courses.Find(CourseId);
            if(course == null){
                return null;
            }
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

        public bool AddCourse(CourseDTO course){

            _db.Courses.Add(new Course {CourseID = course.CourseID,Semester = course.Semester, StartDate = course.StartDate, EndDate = course.EndDate});

            try
            {
                _db.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                return false;
            }
            return true;
        }

        
        public bool UpdateCourse(CourseDTO course, int courseId)
        {

            var original = _db.Courses.Find(courseId);

            if(original == null)
            {
                return false;
            }
            else
            {
                original.StartDate = course.StartDate;
                original.EndDate = course.EndDate;
            }

            try
            {
                _db.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                return false;
            }

            return true;
        }

        public bool DeleteCourse(int courseId)
        {
            var course = _db.Courses.Find(courseId);

            if(course == null)
            {
                return false;
            }
            else
            {
                _db.Courses.Remove(course);
            }

            try
            {
                _db.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                return false;
            }
            
            return true;
        }

        public bool AddStudentToCourse(StudentDTO student, int courseId)
        {
            var stu = (from s in _db.Students
                        where s.SSN == student.SSN
                        select new Student
                        {   ID = s.ID,
                            SSN = s.SSN,
                            Name = s.Name
                        }).SingleOrDefault();
            
            if(stu == null){
                stu = new Student{Name = student.Name, SSN = student.SSN};
                _db.Students.Add(stu);
            }

            try
            {
                _db.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                return false;
            }

            _db.Enrollments.Add(new Enrollment{CourseId = courseId, StudentId = stu.ID});

            try
            {
                _db.SaveChanges();
            }
            catch(DbUpdateException e)
            {
                return false;
            }

            return true;
        }

    }
}