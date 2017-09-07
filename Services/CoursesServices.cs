using System;
using System.Collections.Generic;
using System.Linq;
using CoursesApi.Models;
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

        public void AddStudentToCourse(StudentViewModel student, int courseId)
        {
            int studentID = _repo.GetStudentId(student.SSN);
            var course = _repo.GetCourseById(courseId);

            if( course == null || studentID == -1)
                throw new NotFoundException();

            List<StudentDTO> studentList = _repo.GetStudentsInCourse(courseId).ToList();
            foreach(StudentDTO s in studentList){
                if(s.SSN == student.SSN){
                    throw new AlreadyEnrolledException();
                }
            }

            if(studentList.Count >= course.MaxStudents){
                throw new CourseFullException();
            }

            List<StudentDTO> waitingList = _repo.GetWaitingListForCourse(courseId).ToList();
            foreach(StudentDTO s in waitingList){
                if(s.SSN == student.SSN){
                    _repo.DeleteStudentFromWaitingList(courseId, student.SSN);
                }
            }
            

            _repo.AddStudentToCourse(studentID,courseId);
        }

        public IEnumerable<StudentDTO> GetWaitingListForCourse(int courseId)
        {
            return _repo.GetWaitingListForCourse(courseId);
        }

        public void AddStudentToWaitList(StudentViewModel student, int courseId)
        {
            int studentID = _repo.GetStudentId(student.SSN);

            if(_repo.GetCourseById(courseId) == null || studentID == -1)
                throw new NotFoundException();

                
            List<StudentDTO> studentList = _repo.GetStudentsInCourse(courseId).ToList();
            foreach(StudentDTO s in studentList){
                if(s.SSN == student.SSN){
                    throw new AlreadyEnrolledException();
                }
            }
            List<StudentDTO> waitingList = _repo.GetWaitingListForCourse(courseId).ToList();
            foreach(StudentDTO s in waitingList){
                if(s.SSN == student.SSN){
                    throw new AlreadyEnrolledException();
                }
            }
            _repo.AddStudentToWaitList(studentID,courseId);
        }

        public void DeleteStudentFromWaitingList(int courseId, string studentSSN)
        {
            List<StudentDTO> students = _repo.GetAllStudents().ToList();
            List<StudentDTO> studentsInWaitingList = _repo.GetWaitingListForCourse(courseId).ToList();

            if(_repo.GetCourseById(courseId) == null || students.Where(x => x.SSN == studentSSN) == null){
                throw new NotFoundException();
            }

            if(studentsInWaitingList.Where(x => x.SSN == studentSSN) != null){
                throw new NotEnrolledException();
            }

            _repo.DeleteStudentFromWaitingList(courseId,studentSSN);
        }

        public void RemoveStudentFromCourse(int courseId, string studentSSN)
        {
            List<StudentDTO> students = _repo.GetAllStudents().ToList();
            List<StudentDTO> studentsInCourse = _repo.GetStudentsInCourse(courseId).ToList();

            if(_repo.GetCourseById(courseId) == null || students.Where(x => x.SSN == studentSSN) == null){
                throw new NotFoundException();
            }

            if(studentsInCourse.Where(x => x.SSN == studentSSN) != null){
                throw new NotEnrolledException();
            }

            _repo.RemoveStudentFromCourse(courseId,studentSSN);
        }


    }
}