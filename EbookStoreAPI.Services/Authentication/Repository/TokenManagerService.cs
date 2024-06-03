using AutoMapper;
using EbookStoreAPI.BE;
using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.Authentication.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.Services.Authentication.Repository
{
    public class TokenManagerService : ITokenManagerService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public TokenManagerService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public string GenerateToken(UserDTO user)
        {
            var userBE = _mapper.Map<UserBE>(user);

            var key = _configuration["Jwt:Key"];

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            // Incluir roles en el token
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, userBE.Email),
                new Claim(ClaimTypes.Role, userBE.Role.ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:ValidIssuer"],
                _configuration["Jwt:ValidAudience"],
                claims,
                expires: DateTime.Now.AddMinutes(360),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
