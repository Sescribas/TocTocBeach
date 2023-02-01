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
        /// Gets the price for a ticker symbol
        /// </summary>
        /// <param name="tickerSymbol"></param>
        /// <returns>A SharePriceResponse which contains the price of the share</returns>
        /// <response code="200">Returns 200 and the share price</response>
        /// <response code="400">Returns 400 if the query is invalid</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int? id)
        {
            if (id == null)
                return NotFound();

            var user = _userRepository.Get(id.Value);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if(user == null)
                return BadRequest();

            _userRepository.Add(user);
            _userRepository.Save();

            return Ok(user);
        }

        [HttpPatch(Name = "Update")]
        public IActionResult Update(User user)
        {
            if (user == null)
                return BadRequest();

            _userRepository.Update(user);
            _userRepository.Save();

            return Ok(user);
        }

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
