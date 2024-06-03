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
    public class RoleService : IRoleService
    {
        private readonly IRoleDAL _roleDAL;
        public RoleService(IRoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }
        public async Task<RoleBE> CreateRole(RoleDTO role)
        {
            return await _roleDAL.CreateRole(role);
        }

        public async Task<RoleBE> DeleteRole(int idRole)
        {
            return await _roleDAL.DeleteRole(idRole);
        }

        public async Task<RoleBE> FindById(int idRole)
        {
            return await _roleDAL.FindById(idRole);
        }

        public async Task<List<RoleBE>> GetAllRolesAsync()
        {
            return await _roleDAL.GetAllRolesAsync();
        }

        public async Task<RoleBE> UpdateRole(RoleDTO role)
        {
            return await _roleDAL.UpdateRole(role);
        }
    }
}
