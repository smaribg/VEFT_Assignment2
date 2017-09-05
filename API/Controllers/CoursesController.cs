using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursesApi.Models.ViewModels;
using CoursesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/courses")]
    public class CoursesController : Controller
    {

        private readonly ICoursesServices _coursesService;

        public CoursesController(ICoursesServices coursesServices)
        {
            _coursesService = coursesServices;
        }

        /// <summary>
        /// Returns a list of the courses filtered by the optional
        /// semester query parameter
        /// </summary>
        /// <param name="semester">A string that represents a semester</param>
        /// <returns>A list of courses</returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetCourses([FromQuery]string semester = "20173")
        {
            var courses =  _coursesService.GetCoursesBySemester(semester);

            return Ok(courses);
        }

        /// <summary>
        /// Returns the course corresponding to the given id
        /// </summary>
        /// <param name="courseId">The id of the course</param>
        /// <returns>A course</returns>
        [HttpGet]
        [Route("{courseId}", Name ="GetCourseById")]
        public IActionResult GetCourseById(int courseId){
            var course = _coursesService.GetCourseById(courseId);

            if(course == null){
                return NotFound();
            }

            return Ok(course);
        }

        /// <summary>
        /// Adds a course
        /// </summary>
        /// <param name="course">The course to be added</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public IActionResult AddCourse([FromBody] CourseViewModel course)
        {
            if(course == null){
                return BadRequest();
            }

            if(!ModelState.IsValid){
                return StatusCode(412);
            }

            bool valid = _coursesService.AddCourse(course);

            if(valid)
                return StatusCode(201);
            else
                return StatusCode(412);
        }

        /// <summary>
        /// Updates a course that already exists. StartDate and EndDates can be modified
        /// </summary>
        /// <param name="course">The values being changed</param>
        /// <param name="courseId">The id of the course to be changed</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{courseId}")]
        public IActionResult UpdateCourse([FromBody] CourseUpdateViewModel course, int courseId)
        {
            if(course == null){
                return BadRequest();
            }

            if(!ModelState.IsValid){
                return StatusCode(412);
            }

            bool valid = _coursesService.UpdateCourse(course, courseId);

            if(valid)
                return Ok();
            else
                return StatusCode(404);        
        }

        /// <summary>
        /// Deletes a course
        /// </summary>
        /// <param name="courseId">The id of the course to be deleted</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{courseId}")]
        public IActionResult DeleteCourse(int courseId)
        {
            bool deleted = _coursesService.DeleteCourse(courseId);

            if(!deleted){
                return NotFound("Invalid Id");
            }
            else{
                return StatusCode(204);
            }

        }

        /// <summary>
        /// Returns the students of a course
        /// </summary>
        /// <param name="courseId">The id of the course </param>
        /// <returns>A list of the students in the given course</returns>
        [HttpGet]
        [Route("{courseId}/students")]
        public IActionResult GetStudentsInCourse(int courseId)
        {
            var students = _coursesService.GetStudentsInCourse(courseId);

            if(students == null){
                return NotFound("Invalid Id");
            }

            return Ok(students);
        }

        /// <summary>
        /// Adds a student to a course
        /// </summary>
        /// <param name="student">The student being added</param>
        /// <param name="courseId">The id of the course that the student is being added to</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{courseId}/students")]
        public IActionResult AddStudentToCourse([FromBody] StudentViewModel student, int courseId)
        {
            if(student == null){
                return BadRequest();
            }

            if(!ModelState.IsValid){
                return StatusCode(412);
            }

            bool valid = _coursesService.AddStudentToCourse(student,courseId);

            if(valid)
                return StatusCode(201);
            else
                return StatusCode(412);
        }
    

    }
}
