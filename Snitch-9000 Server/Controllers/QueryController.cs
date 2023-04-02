using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using snitch_9000.Models;
using snitch_9000.Data;
using snitch_9000.DTOs;
using snitch_9000.Utilities;

namespace snitch_9000.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QueryController : Controller
    {
        private readonly ISnitchRepo _repository;

        public QueryController(ISnitchRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("{query}")]
        public IActionResult queryString(string query)
        {
            // Single query no question object associated for single use

            ICollection<Hit> hits = Scraper.GetHits(query);

            if(hits.Count != 0)
            {
                return Ok(hits);
            } else {
                return BadRequest();
            }
        }

        [HttpGet("question/{questionID}")]
        public IActionResult queryQuestion(int questionID)
        {
            try
            {
                Question question = _repository.GetQuestionById(questionID);
                if (question != null)
                {
                    var storedHits = _repository.GetHitsByQuestionId(questionID);
                    string queryString = question.content;
                    ICollection<Hit> hits = Scraper.GetHits(queryString);
                    foreach(Hit hit in hits)
                    {
                        var match = storedHits.FirstOrDefault(sh => sh.link == hit.link);
                        if (match == null)
                        {
                            hit.question = question;
                            _repository.CreateHit(hit);
                        }
                    }

                    if (_repository.SaveChanges())
                    {
                        Console.WriteLine(question.content);
                        return Ok(_repository.GetHitsByQuestionId(questionID));
                    }   
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("course/{course_id}")]
        public IActionResult queryCourse(string course_id)
        {
            ICollection<Hit> hits_return = new List<Hit>();
            try
            {
                Course course = _repository.GetCourseById(course_id);
                if (course != null)
                {
                    IEnumerable<Question> questions = _repository.GetQuestionsByCourseId(course_id);
                    Console.WriteLine(questions);
                    foreach(Question question in questions)
                    {
                        String queryString = question.content;
                        ICollection<Hit> hits = Scraper.GetHits(queryString);
                        foreach(Hit hit in hits)
                        {
                            hit.question = question;
                            _repository.CreateHit(hit);
                            if (_repository.SaveChanges())
                            {
                                HitDTO dto = new HitDTO();
                                dto.id = hit.hit_id;
                                dto.question_id = question.question_id;
                                hits_return.Add(hit);
                            }
                        }
                    }
                if (_repository.SaveChanges())
                {
                    return Ok(hits_return);
                }
                else
                {
                    return StatusCode(500);
                }
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}