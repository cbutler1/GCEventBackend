using Event.Data;
using Event.Data.TableModels;

namespace Event.Services.Services
{
    public interface IUserService
    {
        User CreateUser(string name);
        ICollection<User> GetUsers();
        User GetUserById(int id);
        User UpdateUser(User student, string name);
        bool DeleteUser(int id);
    }


    public class UserService : IUserService
    {
        private readonly EventDbContext _context;

        private readonly HttpClient _client;

        public UserService(EventDbContext context, HttpClient client)
        {
            _context = context;
            _client = client;
        }

        public User CreateUser(string name)
        {
            User user = new User
            {
                Name = name
            };
            
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public User UpdateUser(User user, string name)
        {
            user.Name = name;

            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }



        public bool DeleteUser(int id)
        {
            var user = GetUserById(id);

            if(user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return true;
        }
    }
}
