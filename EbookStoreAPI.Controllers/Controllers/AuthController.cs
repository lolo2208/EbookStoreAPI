using AutoMapper;
using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.Authentication.Interfaces;
using EbookStoreAPI.Services.Authentication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EbookStoreAPI.Controllers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthenticationService _authService;
        private readonly ITokenManagerService _tokenManagerService;
        private readonly IMapper _mapper;

        public AuthController(IAuthenticationService authService, ITokenManagerService tokenManagerService, IMapper mapper)
        {
            _authService = authService;
            _tokenManagerService = tokenManagerService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserBE>> Login(UserDTO user)
        {
            ActionResult response = Unauthorized();

            if (user is not null)
            {
                var authUser = await _authService.AuthenticateUser(user);            

                if (authUser is not null)
                {
                    var authUserDTO = _mapper.Map<UserDTO>(authUser);
                    var token = _tokenManagerService.GenerateToken(authUserDTO);
                    response = Ok(new {
                        authUser = authUserDTO,
                        token
                    });
                }
            }
            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserBE>> Register(UserDTO user)
        {
            if (user is not null)
            {
                var newUser = await _authService.Register(user);

                if (newUser is not null)
                {
                    return Ok(newUser);
                }
            }
            return BadRequest();
        }
    }
}
