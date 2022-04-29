namespace User.API.Controllers
{
    using Domain;
    using Domain.Contracts;

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            int result = await _userService.InsertUser(user);

            if (result > 0)
            {
                return Ok("Inserted successfully");
            }

            return BadRequest("Duplicate User");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            User? result = await _userService.UpdateUser(id, user);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllUser());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User? user = await _userService.GetUser(id);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }

        /// <summary>
        ///     Search user by first name or last name
        /// </summary>
        [HttpGet("search/{input}")]
        public async Task<IActionResult> Search(string input)
        {
            User? user = await _userService.SearchUser(input);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }
    }
}