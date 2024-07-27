using marquee_backend.Data;
using marquee_backend.ViewModel.Auth;
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
            
            //var userDtos = _
            return Ok(users);
        }
    }
}
