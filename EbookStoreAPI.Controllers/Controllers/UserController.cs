using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.EntitiesServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EbookStoreAPI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{idUser}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserById(int idUser)
        {
            try
            {
                var findedUser = await _userService.FindById(idUser);
                return Ok(findedUser);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO user)
        {
            try
            {
                var addedUser = await _userService.CreateUser(user);
                return Ok(addedUser);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut("{idUser}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(UserDTO user, int idUser)
        {
            try
            {
                if (idUser == user.IdUser)
                {
                    var updatedUser = await _userService.UpdateUser(user);
                    return Ok(updatedUser);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete("{idUser}")]
        public async Task<ActionResult<UserDTO>> DeleteUser(int idUser)
        {
            try
            {
                {
                    var findedUser = await _userService.FindById(idUser);
                    if (findedUser != null)
                    {
                        var deletedUser = await _userService.DeleteUser(findedUser.IdUser);
                        return Ok(deletedUser);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
