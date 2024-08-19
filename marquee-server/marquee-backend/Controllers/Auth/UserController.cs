using marquee_backend.Data;
using marquee_backend.Models.Auth;
using marquee_backend.Models.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marquee_backend.Controllers.Auth
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MarqueeDatabaseContext _databaseContext;

        public UserController (MarqueeDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _databaseContext.Users.ToListAsync();

            if (users == null || !users.Any())
            {
                return NotFound(); 
            }  
            
            return users;
        }

        [HttpGet("{userId}", Name = "GetUserById")]
        public async Task<ActionResult<User>> GetRentable (Guid userId)
        {
            var user = await _databaseContext.Users.FindAsync(userId);
            if (user == null)
                return NotFound();
            
            return user;
        }

        [HttpPost(Name = "AddUser")]
        public async Task<IActionResult> AddUser (User newUser) 
        {
            newUser.Id = Guid.NewGuid();
            // TODO Check that user does not already exist based on restrictions (username?)
            _databaseContext.Users.Add(newUser);
            await _databaseContext.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPut("{userId}", Name = "EditUser")]
        public async Task<IActionResult> EditUser (Guid userId, User updatedUser)
        {
            if (userId != updatedUser.Id)
                return BadRequest();
            
            _databaseContext.Entry(updatedUser).State = EntityState.Modified;

            try
            {
                await _databaseContext.SaveChangesAsync();
            } 
            catch (DbUpdateConcurrencyException)
            {
                var user = await _databaseContext.Users.FindAsync(userId);
                if (user == null)
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }
    }
}
