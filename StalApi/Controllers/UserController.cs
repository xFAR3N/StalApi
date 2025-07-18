using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StalApi.Data;
using StalApi.Dtos.User;
using StalApi.Mappers;

namespace StalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _contex;
        public UserController(AppDbContext contex)
        {
            _contex = contex;
        }
        [HttpGet]
        public IActionResult GetAllUsers() 
        {
            var users = _contex.User.ToList()
                .Select(s => s.ToUserDto());

            return Ok(users);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser([FromRoute]Guid id)
        {
            var user = _contex.User.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToUserFromCreateDto();
            _contex.User.Add(userModel);
            _contex.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new {id = userModel.Id }, userModel);
        }
    }
}
