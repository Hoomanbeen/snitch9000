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
    public class HitController : Controller
    {
        private readonly ISnitchRepo _repository;

        public HitController(ISnitchRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("getall")]
        public IActionResult getAllHits()
        {
            try
            {
                var hits = _repository.GetAllHits();
                return Ok(hits);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("getbyquestionid/{id}")]
        public IActionResult getHitsByQuestionId(int id)
        {
            try
            {
                var hit = _repository.GetHitsByQuestionId(id);
                Console.WriteLine(hit);
                Console.WriteLine(hit.ToList<Hit>()[0].question.content);
                return Ok(hit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("getbycourse/{id}")]
        public IActionResult getHitsByCourseId(string id)
        {
            try
            {
                var hit = _repository.GetHitsByCourseId(id);
                return Ok(hit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("getuserhits")]
        public IActionResult getUserHits()
        {
            try
            {
                User u = Authenticate.AuthenticateUser(_repository, this.HttpContext);
                if(u == null) return BadRequest();

                List<Course> courses = u.courses.ToList();
                
                List<Hit> hits = new List<Hit>();

                foreach(Course course in courses)
                {
                    hits.AddRange(_repository.GetHitsByCourseId(course.course_id));
                }

                return Ok(hits);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}