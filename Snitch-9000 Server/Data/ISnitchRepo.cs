using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using snitch_9000.Models;

namespace snitch_9000.Data
{
    public interface ISnitchRepo
    {
        bool SaveChanges();
        IEnumerable<Question> GetAllQuestions();
        IEnumerable<Question> GetQuestionsByUser(int userId);
        IEnumerable<Question> GetQuestionsByCourseId(string id);
        Question GetQuestionById(int id);
        void CreateQuestion(Question question);
        void UpdateQuestion(Question question, int question_id);
        void DeleteQuestion(Question question);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        IEnumerable<Hit> GetAllHits();
        IEnumerable<Hit> GetHitsByQuestionId(int id);
        IEnumerable<Hit> GetHitsByCourseId(string id);
        Hit GetHitById(int id);
        void CreateHit(Hit hit);
        void DeleteHit(Hit hit);
        IEnumerable<Notification> GetAllNotifications();
        IEnumerable<Notification> GetNotificationsByUserId(int id);
        Notification GetNotificationById(int id);
        void CreateNotification(Notification notification);
        void DeleteNotification(Notification notification);
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(string id);
        void CreateCourse(Course course);
        void UpdateCourse(Course course, string course_id);
        void DeleteCourse(Course course);
    }
}