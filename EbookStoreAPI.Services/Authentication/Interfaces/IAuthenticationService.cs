using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.Services.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserBE> Login(UserDTO user);
        Task<UserBE> Register(UserDTO user);
        Task<UserBE> AuthenticateUser(UserDTO user);
    }
}
