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

        [HttpPost]
        [Route("")]
        public IActionResult AddCourse([FromBody] CourseViewModel course)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{courseId}")]
        public IActionResult UpdateCourse([FromBody] CourseViewModel course, int courseId)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{courseId}")]
        public IActionResult DeleteCourse(int courseId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{courseId}/students")]
        public IActionResult GetStudentsInCourse(int courseId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("{courseId}/students")]
        public IActionResult AddStudentToCourse([FromBody] StudentViewModel student, int courseId)
        {
            return Ok();
        }
    

    }
}
