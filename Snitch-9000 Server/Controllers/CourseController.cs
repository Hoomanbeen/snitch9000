using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using snitch_9000.Models;
using snitch_9000.Data;
using snitch_9000.DTOs;
using snitch_9000.Utilities;


namespace snitch_9000.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ISnitchRepo _repository;

        public CourseController(ISnitchRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("add")]
        public IActionResult addCourse(CourseDTO courseDTO)
        {
            try
            {
                Course course = new Course();
                course.course_id = courseDTO.courseCode;
                User user = Authenticate.AuthenticateUser(_repository, this.HttpContext);

                // Add user if logged in
                if(user != null) 
                {
                    course.user.Append(user);
                    user.courses.Append(course);
                }

                _repository.CreateCourse(course);
                if (_repository.SaveChanges())
                {
                    return Ok(courseDTO);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        public IActionResult deleteCourse(string course_id)
        {
            try
            {
                Course course = _repository.GetCourseById(course_id);
                _repository.DeleteCourse(course);
                if (_repository.SaveChanges())
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("getall")]
        public IActionResult getAllCourses()
        {
            try
            {   
                User u = Authenticate.AuthenticateUser(_repository, this.HttpContext);
                List<Course> courses;
                if(u != null)
                {
                    courses = u.courses.ToList();
                }
                else 
                {
                    courses = _repository.GetAllCourses().ToList();
                }

                List<String> courseCodes = new List<string>();
                foreach (Course course in courses)
                {
                    courseCodes.Add(course.course_id);
                }
                return Ok(courseCodes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}