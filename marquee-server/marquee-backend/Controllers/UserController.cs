using marquee_backend.Data;
using marquee_backend.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace marquee_backend.Controllers
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
        public async Task<IActionResult> GetUsers()
        {
            var users = await _databaseContext.Users.ToListAsync();

            if (users == null || !users.Any())
            {
                return NotFound(); 
            }  
            
            return Ok(users);
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
    }
}
