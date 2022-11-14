using Microsoft.EntityFrameworkCore;
using Event.Data;
//using Event.Data.DTOs;
using Event.Data.TableModels;

namespace Event.Services.Services
{
    public interface IThingToDoService
    {
        ThingToDo CreateThingToDo(string eventName, double price, string location, DateTime time);
        ICollection<ThingToDo> GetThingToDos();
        ThingToDo GetThingToDoById(int id);
        //CourseStudentList GetStudentsForCourseId(int id);
    }

    public class ThingToDoService : IThingToDoService
    {
        private readonly EventDbContext _context;
        
        public ThingToDoService(EventDbContext context)
        {
            _context = context;
        }
        
        public ThingToDo CreateThingToDo(string eventName, double price, string location, DateTime time)
        {
            ThingToDo course = new ThingToDo() { EventName = eventName, Price = price, Location = location, Time = time };

            _context.ThingToDos.Add(course);
            _context.SaveChanges();

            return course;
        }

        public ThingToDo? GetThingToDoById(int id)
        {
            return _context.ThingToDos.SingleOrDefault(c => c.Id == id);
        }

        public ICollection<ThingToDo> GetThingToDos()
        {
            return _context.ThingToDos.ToList(); //example of eager loading
        }

        //CourseThingToDoList IThingToDoService.GetStudentsForCourseId(int id)
        //{
        //    //Course course = _context.Courses.Single(c => c.ID == id);
        //    //ICollection<Student> students = _context.Enrollments
        //    //    .Where(e => e.CourseID == id)
        //    //    .Select(e => e.Student)
        //    //    .ToList();

        //    //var csl = new CourseStudentList() 
        //    //{ 
        //    //    CourseID = id, 
        //    //    CourseTitle = course.Title, 
        //    //    CourseTeacher = course.Teacher, 
        //    //    Students = students 
        //    //};

        //    //return csl;

        //    return _context.Courses.Where(c => c.ID == id)
        //        .Select(c => new CourseStudentList()
        //        {
        //            CourseID = c.ID,
        //            CourseTitle = c.Title,
        //            CourseTeacher = c.Teacher,
        //            Students = c.Enrollments.Select(e => e.Student).ToList()
        //        }).FirstOrDefault();

        //}

    }
}
