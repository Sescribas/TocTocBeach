using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TocTocBeach.Models;
using TocTocBeach.Repository;
using TocTocBeach.Repository.Interface;

namespace TocTocBeach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository= userRepository;  
        }

        /// <summary>
        /// Get all the user
        /// </summary>
        /// <returns>return a list with all available users</returns>
        /// <response code="200">Returns 200 with a user list</response>
        /// <response code="400">Returns 400 if doesn't have users in the database</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        /// <summary>
        /// Get a user by id 
        /// </summary>
        /// <returns>return an user</returns>
        /// <response code="200">Returns 200 with a user</response>
        /// <response code="400">Returns 400 if the user not exist in the database</response>
        [HttpGet("{id:int}")]
        public IActionResult GetUser(int? id)
        {
            if (id == null)
                return NotFound();

            var user = _userRepository.Get(id.Value);
            return Ok(user);
        }

        /// <summary>
        /// Create a user 
        /// </summary>
        /// <returns>return the user created</returns>
        /// <response code="200">Returns 200 with a user created</response>
        /// <response code="400">Returns 400 if if there was any problem with the registration</response>
        [HttpPost]
        public IActionResult Create([FromBody]User user)
        {
            if(user == null)
                return BadRequest();

            _userRepository.Add(user);
            _userRepository.Save();

            return Ok(user);
        }
        /// <summary>
        /// Update a existing user
        /// </summary>
        /// <returns>return the user updated</returns>
        /// <response code="200">Returns 200 with a user updated</response>
        /// <response code="400">Returns 400 if if there was any problem with the registration</response>
        [HttpPatch(Name = "Update")]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            _userRepository.Update(user);
            _userRepository.Save();

            return Ok(user);
        }


        /// <summary>
        /// Delete a existing user
        /// </summary>
        /// <response code="200">Returns 200 with a user deleted</response>
        /// <response code="400">Returns 400 if if there was any problem with the registration</response>
        [HttpDelete("{id:int}",Name = "Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var userToDelete = _userRepository.Get(id.Value);
            
            if (userToDelete == null)
                return NotFound();

            _userRepository.Delete(userToDelete);
            _userRepository.Save();

            return Ok();
        }

    }
}
