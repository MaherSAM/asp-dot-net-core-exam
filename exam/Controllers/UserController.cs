using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Services;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound(new { message = $"User with ID {id} not found." });
            }
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto userDto)
        {
            // ModelState validation is handled automatically by [ApiController]
            // based on Data Annotations in UserDto.cs (Activity 2 Validation)

            var createdUser = _userService.Add(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto userDto)
        {
            var updated = _userService.Update(id, userDto);
            if (!updated)
            {
                return NotFound(new { message = "User not found." });
            }
            return NoContent();
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var deleted = _userService.Delete(id);
            if (!deleted)
            {
                return NotFound(new { message = "User not found." });
            }
            return NoContent();
        }

        // Endpoint to test Global Exception Handler (Activity 3)
        [HttpGet("trigger-error")]
        public IActionResult TriggerError()
        {
            throw new Exception("This is a forced test exception!");
        }
    }
}