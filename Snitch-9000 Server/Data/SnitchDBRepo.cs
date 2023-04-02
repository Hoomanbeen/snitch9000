using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using snitch_9000.Models;

namespace snitch_9000.Data
{
    public class SnitchDBRepo : ISnitchRepo
    {
        private readonly SnitchContext _context;

        public SnitchDBRepo(SnitchContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _context.QUESTIONS.Include(question => question.courses).ToList();
        }

        public IEnumerable<Question> GetQuestionsByUser(int userId)
        {
            return _context.QUESTIONS.Where(q => q.user.user_id == userId).ToList();
        }

        public IEnumerable<Question> GetQuestionsByCourseId(string id)
        {
            Course course = _context.COURSES.FirstOrDefault(c => c.course_id == id);
            IEnumerable<Question> questions = _context.QUESTIONS.Include(question => question.courses).Where(q => q.courses.Contains(course)).ToList();
            return questions;
        }

        public Question GetQuestionByUserId(int id)
        {
            return _context.QUESTIONS.FirstOrDefault(q => q.user.user_id == id);
        }

        public Question GetQuestionById(int id)
        {
            // return _context.QUESTIONS.Include(question => question.courses).FirstOrDefault(q => q.question_id == id);
            return _context.QUESTIONS.FirstOrDefault(q => q.question_id == id);
        }

        public void CreateQuestion(Question question)
        {
            if (question == null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            _context.QUESTIONS.Add(question);
        }

        public void UpdateQuestion(Question question, int question_id)
        {
            // Nothing

            Question old = GetQuestionById(question_id);
            old.title = question.title;
            old.content = question.content;
            old.keywords = question.keywords;
            old.tags = question.tags;
        }
        
        public void UpdateCourse(Course course, string course_id)
        {
            Course old = GetCourseById(course_id);
            old.course_id = course.course_id;
            old.question = course.question;
            old.user = course.user;
        }

        public void DeleteQuestion(Question question)
        {
            if (question == null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            _context.QUESTIONS.Remove(question);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.USERS.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.USERS.Include(user => user.courses).FirstOrDefault(u => u.user_id == id);
        }

        public User GetUserByEmail(string email)
        {
            return _context.USERS.Include(user => user.courses).FirstOrDefault(u => u.email == email);
        }

        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.USERS.Add(user);
        }

        public void UpdateUser(User user)
        {
            // Nothing
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.USERS.Remove(user);
        }

        public IEnumerable<Hit> GetAllHits()
        {
            return _context.HITS.Include(hit => hit.question).ToList();
        }

        public IEnumerable<Hit> GetHitsByQuestionId(int id)
        {
            return _context.HITS.Include(question => question.question).Where(h => h.question.question_id == id).ToList();
        }

        public IEnumerable<Hit> GetHitsByCourseId(string id)
        {
            Course course = _context.COURSES.FirstOrDefault(c => c.course_id == id);
            IEnumerable<Question> questions = _context.QUESTIONS.Where(q => q.courses.Contains(course)).ToList();
            List<Hit> hits = new List<Hit>();
            foreach (Question question in questions)
            {
                hits.AddRange(_context.HITS.Include(hits => hits.question).Where(h => h.question.question_id == question.question_id).ToList());
            }
            return hits;
        }

        public Hit GetHitById(int id)
        {
            return _context.HITS.Include(hit => hit.question).FirstOrDefault(h => h.hit_id == id);
        }

        public void CreateHit(Hit hit)
        {
            if (hit == null)
            {
                throw new ArgumentNullException(nameof(hit));
            }

            _context.HITS.Add(hit);
        }

        public void DeleteHit(Hit hit)
        {
            if (hit == null)
            {
                throw new ArgumentNullException(nameof(hit));
            }

            _context.HITS.Remove(hit);
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return _context.NOTIFICATIONS.ToList();
        }

        public IEnumerable<Notification> GetNotificationsByUserId(int id)
        {
            return _context.NOTIFICATIONS.Where(n => n.user.user_id == id).ToList();
        }

        public Notification GetNotificationById(int id)
        {
            return _context.NOTIFICATIONS.FirstOrDefault(n => n.notification_id == id);
        }

        public void CreateNotification(Notification notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            _context.NOTIFICATIONS.Add(notification);
        }

        public void DeleteNotification(Notification notification)
        {
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification));
            }

            _context.NOTIFICATIONS.Remove(notification);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.COURSES.Include(course => course.question).ToList();
        }

        public Course GetCourseById(string id)
        {
            return _context.COURSES.Include(course => course.question).Include(course => course.user).FirstOrDefault(c => c.course_id == id);
        }

        public void CreateCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.COURSES.Add(course);
        }

        public void DeleteCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            _context.QUESTIONS.RemoveRange(course.question);
            _context.COURSES.Remove(course);
        }
    }
}