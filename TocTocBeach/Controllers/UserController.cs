using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TocTocBeach.Repository;

namespace TocTocBeach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context= context;  
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users;
            return Ok(users);
        }
    }
}
