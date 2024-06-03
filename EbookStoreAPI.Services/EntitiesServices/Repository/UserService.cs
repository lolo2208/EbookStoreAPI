using EbookStoreAPI.BE;
using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.EntitiesServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.Services.EntitiesServices.Repository
{
    public class UserService : IUserService
    {
        private readonly IUserDAL _userDAL;
        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public async Task<UserBE> CreateUser(UserDTO user)
        {
            return await _userDAL.CreateUser(user);
        }

        public async Task<UserBE> DeleteUser(int idUser)
        {
            return await _userDAL.DeleteUser(idUser);
        }

        public async Task<UserBE> FindByAuthentication(UserDTO user)
        {
            return await _userDAL.FindByAuthentication(user);
        }

        public async Task<UserBE> FindById(int idUser)
        {
            return await _userDAL.FindById(idUser);
        }

        public async Task<List<UserBE>> GetAllUsersAsync()
        {
            return await _userDAL.GetAllUsersAsync();
        }

        public async Task<UserBE> UpdateUser(UserDTO user)
        {
            return await _userDAL.UpdateUser(user);
        }
    }
}
