using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.Services.EntitiesServices.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleBE>> GetAllRolesAsync();
        Task<RoleBE> CreateRole(RoleDTO role);
        Task<RoleBE> UpdateRole(RoleDTO role);
        Task<RoleBE> DeleteRole(int idRole);
        Task<RoleBE> FindById(int idRole);
    }
}
