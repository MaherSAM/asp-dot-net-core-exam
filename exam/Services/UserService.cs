using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public class UserService : IUserService
    {
        // Simulating a database with an in-memory list
        private static readonly List<User> _users = new List<User>();
        private static int _nextId = 1;

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User? GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public User Add(CreateUserDto userDto)
        {
            var user = new User
            {
                Id = _nextId++,
                Name = userDto.Name,
                Email = userDto.Email,
                Department = userDto.Department
            };
            _users.Add(user);
            return user;
        }

        public bool Update(int id, UpdateUserDto userDto)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null) return false;

            existingUser.Name = userDto.Name;
            existingUser.Email = userDto.Email;
            existingUser.Department = userDto.Department;
            return true;
        }

        public bool Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;

            _users.Remove(user);
            return true;
        }
    }
}