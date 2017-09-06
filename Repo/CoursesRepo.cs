using System;
using System.Linq;
using System.Collections.Generic;
using CoursesApi.Models.DTOs;
using CoursesApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using CoursesApi.Models;

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
                                EndDate = c.EndDate,
                                MaxStudents = c.MaxStudents
                                
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

            _db.Courses.Add(new Course {CourseID = course.CourseID,Semester = course.Semester, StartDate = course.StartDate, EndDate = course.EndDate, MaxStudents = course.MaxStudents});

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
                original.MaxStudents = course.MaxStudents;
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

        public int GetStudentId(String SSN){
            var stu = (from s in _db.Students
                        where s.SSN == SSN
                        select new Student
                        {   ID = s.ID,
                            SSN = s.SSN,
                            Name = s.Name
                        }).SingleOrDefault();
            if(stu == null){
                return -1;
            }
            return stu.ID;
        }

        public bool AddStudentToCourse(int studentId, int courseId)
        {
            _db.Enrollments.Add(new Enrollment{CourseId = courseId, StudentId = studentId});

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
        
        public IEnumerable<StudentDTO> GetWaitingListForCourse(int courseId)
        {
            var course = _db.Courses.Find(courseId);
            if(course == null){
                return null;
            }
            var students = (from s in _db.Students
                            join wn in _db.WaitingLists on s.ID equals wn.StudentId
                            where wn.CourseId == courseId
                            select new StudentDTO
                            {
                                Name = s.Name,
                                SSN = s.SSN
                            }).ToList();
            return students;
        }

        public bool AddStudentToWaitList(int studentID, int courseId)
        {

            _db.WaitingLists.Add(new WaitingList{CourseId = courseId, StudentId = studentID});

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

        public void DeleteStudentFromWaitingList(int courseId, string studentSSN)
        {

        }

        public IEnumerable<StudentDTO> GetAllStudents(){
            var students = (from s in _db.Students
                            select new StudentDTO{
                                Name = s.Name,
                                SSN = s.SSN,
                            }).ToList();
            return students;
        }

    }
}