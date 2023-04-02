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
    public class QuestionController : Controller
    {
        private readonly ISnitchRepo _repository;

        public QuestionController(ISnitchRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("add")]
        public IActionResult addQuestion(PostDTO questionDTO)
        {
            try
            {
                Question question = new Question();
                question.title = questionDTO.title;
                question.content = questionDTO.content;
                question.keywords = questionDTO.keywords;
              
                
                question.start_date = DateTime.Now;
                
                question.courses = new List<Course>();

                foreach (string course in questionDTO.courses)
                {
                    Course c = _repository.GetCourseById(course);

                    if (c != null)
                    {
                        User u = Authenticate.AuthenticateUser(_repository, this.HttpContext);
                        if (u != null) {
                            Console.WriteLine(c.user.Count());
                            c.user.Append(u);
                        }
                        question.courses.Add(c);
                        // _repository.UpdateCourse(c, c.course_id);
                        Console.WriteLine(c.course_id);
                    }
                    else 
                    {
                        c = new Course();
                        c.course_id = course;
                        c.question = new List<Question>();
                        c.question.Append(question);
                        question.courses.Add(c);
                        User u = Authenticate.AuthenticateUser(_repository, this.HttpContext);
                        if (u != null) c.user.Append(u);
                        _repository.CreateCourse(c);
                    }
                }
                // TODO: Add user

                _repository.CreateQuestion(question);
                if (_repository.SaveChanges())
                {
                    return Ok(questionDTO);
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

        [HttpPost("delete")]
        public IActionResult deleteQuestion(int question_id)
        {
            try
            {
                Question question = _repository.GetQuestionById(question_id);
                _repository.DeleteQuestion(question);
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

        [HttpGet("get")]
        public IActionResult getQuestion(int question_id)
        {
            try
            {
                Question question = _repository.GetQuestionById(question_id);

                if (question != null)
                {
                    QuestionDTO questionDTO = new QuestionDTO();
                    questionDTO.question_id = question.question_id;
                    questionDTO.title = question.title;
                    questionDTO.content = question.content;
                    questionDTO.keywords = question.keywords;
                    questionDTO.courses = new List<String>();

                    foreach(Course course in question.courses)
                    {
                        questionDTO.courses.Add(course.course_id);
                    }

                    questionDTO.tags = question.tags;
                    questionDTO.start_date = question.start_date;

                    return Ok(questionDTO);
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

        [HttpGet("getall")]
        public IActionResult getAllQuestions()
        {
            try
            {
                IEnumerable<Question> questions = _repository.GetAllQuestions();
                if (questions != null)
                {
                    List<QuestionDTO> questionDTOs = new List<QuestionDTO>();

                    foreach(Question question in questions)
                    {
                        QuestionDTO questionDTO = new QuestionDTO();
                        questionDTO.question_id = question.question_id;
                        questionDTO.title = question.title;
                        questionDTO.content = question.content;
                        questionDTO.keywords = question.keywords;
                        questionDTO.courses = new List<String>();

                        foreach(Course course in question.courses)
                        {
                            questionDTO.courses.Add(course.course_id);
                        }

                        questionDTO.tags = question.tags;
                        questionDTO.start_date = question.start_date;
                        questionDTOs.Add(questionDTO);
                    }
                    return Ok(questionDTOs);
                }
                else 
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpGet("getbycourse/{course}")]
        public IActionResult GetQuestionsByCourse(string course)
        {
            try
            {
                IEnumerable<Question> questions = _repository.GetQuestionsByCourseId(course);
                if (questions != null)
                {
                    List<QuestionDTO> questionDTOs = new List<QuestionDTO>();

                    foreach(Question question in questions)
                    {
                        QuestionDTO questionDTO = new QuestionDTO();
                        questionDTO.question_id = question.question_id;
                        questionDTO.title = question.title;
                        questionDTO.content = question.content;
                        questionDTO.keywords = question.keywords;
                        questionDTO.courses = new List<String>();

                        foreach(Course c in question.courses)
                        {
                            questionDTO.courses.Add(c.course_id);
                        }

                        questionDTO.tags = question.tags;
                        questionDTO.start_date = question.start_date;
                        questionDTOs.Add(questionDTO);
                    }
                    return Ok(questionDTOs);
                }
                else 
                {
                    return BadRequest();
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        [HttpPost("update/{id}")]
        public IActionResult UpdateQuestion(PostDTO updated, int question_id)
        {
            try 
            {
                Question question = _repository.GetQuestionById(question_id);

                if (question != null)
                {
                    Question q = new Question();
                    q.title = updated.title;
                    q.content = updated.content;
                    q.keywords = updated.keywords;
                    q.tags = updated.tags;

                    // TODO: CREATE DTO HELPER CLASS

                    _repository.UpdateQuestion(q, question_id);
                    if (_repository.SaveChanges())
                    {
                        QuestionDTO questionDTO = new QuestionDTO();
                        questionDTO.title = q.title;
                        questionDTO.content = q.content;
                        questionDTO.keywords = q.keywords;
                        List<String> c = new List<String>();
                        foreach(Course course in question.courses)
                        {
                            c.Add(course.course_id);
                        }
                        questionDTO.courses = c;
                        questionDTO.tags = q.tags;
                        questionDTO.start_date = question.start_date;

                        return Ok(questionDTO);
                    }
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else 
                {
                    return BadRequest();
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