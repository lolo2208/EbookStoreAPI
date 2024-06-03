using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.Services.EntitiesServices.Interfaces
{
    public interface IUserService
    {
        Task<List<UserBE>> GetAllUsersAsync();
        Task<UserBE> CreateUser(UserDTO user);
        Task<UserBE> UpdateUser(UserDTO user);
        Task<UserBE> DeleteUser(int idUser);
        Task<UserBE> FindById(int idUser);
        Task<UserBE> FindByAuthentication(UserDTO user);
    }
}
