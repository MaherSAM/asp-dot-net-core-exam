using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        User Add(CreateUserDto userDto);
        bool Update(int id, UpdateUserDto userDto);
        bool Delete(int id);
    }
}