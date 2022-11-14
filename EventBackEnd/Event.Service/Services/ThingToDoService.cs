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
        private readonly SchoolDbContext _context;
        
        public CourseService(SchoolDbContext context)
        {
            _context = context;
        }
        
        public ThingToDo CreateCourse(string title, string teacher)
        {
            ThingToDo course = new ThingToDo() { Title = title, Teacher = teacher };

            _context.Courses.Add(course);
            _context.SaveChanges();

            return course;
        }

        public ThingToDo? GetCourseById(int id)
        {
            return _context.Courses.SingleOrDefault(c => c.ID == id);
        }

        public ICollection<ThingToDo> GetCourses()
        {
            return _context.Courses.Include("Enrollments").ToList(); //example of eager loading
        }

        CourseStudentList ICourseService.GetStudentsForCourseId(int id)
        {
            //Course course = _context.Courses.Single(c => c.ID == id);
            //ICollection<Student> students = _context.Enrollments
            //    .Where(e => e.CourseID == id)
            //    .Select(e => e.Student)
            //    .ToList();

            //var csl = new CourseStudentList() 
            //{ 
            //    CourseID = id, 
            //    CourseTitle = course.Title, 
            //    CourseTeacher = course.Teacher, 
            //    Students = students 
            //};

            //return csl;

            return _context.Courses.Where(c => c.ID == id)
                .Select(c => new CourseStudentList()
                {
                    CourseID = c.ID,
                    CourseTitle = c.Title,
                    CourseTeacher = c.Teacher,
                    Students = c.Enrollments.Select(e => e.Student).ToList()
                }).FirstOrDefault();

        }

    }
}
