using AutoMapper;
using EbookStoreAPI.BE;
using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DBConnection;
using EbookStoreAPI.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DAL.Repositories
{
    public class RoleDAL : IRoleDAL
    {
        private readonly EbookStoreDbContext _context;
        private readonly IMapper _mapper;

        public RoleDAL(EbookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoleBE> CreateRole(RoleDTO role)
        {
            try
            {
                var RoleBE = _mapper.Map<RoleBE>(role);
                _context.Roles.Add(RoleBE);
                await _context.SaveChangesAsync();

                await _context.Entry(RoleBE).ReloadAsync();

                return RoleBE;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating role.", ex);
            }

        }

        public async Task<RoleBE> DeleteRole(int idRole)
        {
            try
            {
                var toDeleteRole = await _context.Roles.FindAsync(idRole);

                if (toDeleteRole == null)
                {
                    throw new Exception("Role not found");
                }

                _context.Roles.Remove(toDeleteRole);
                await _context.SaveChangesAsync();

                return toDeleteRole;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting role", ex);
            }
        }

        public async Task<RoleBE> FindById(int idRole)
        {
            try
            {
                var findedRole = await _context.Roles.FindAsync(idRole);

                if (findedRole == null)
                {
                    throw new Exception("Role not found");
                }

                return findedRole;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting role", ex);
            }
        }

        public async Task<List<RoleBE>> GetAllRolesAsync()
        {
            if (_context.Roles == null)
            {
                throw new Exception("No roles found");
            }
            return await _context.Roles.ToListAsync();
        }

        public async Task<RoleBE> UpdateRole(RoleDTO role)
        {
            try
            {
                var existingRole = await _context.Roles.FindAsync(role.IdRole);
                var RoleBE = _mapper.Map<RoleBE>(role);

                if (existingRole == null)
                {
                    throw new Exception("Role not found");
                }

                _context.Entry(existingRole).CurrentValues.SetValues(RoleBE);
                await _context.SaveChangesAsync();

                await _context.Entry(existingRole).ReloadAsync();

                return existingRole;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating role", ex);
            }
        }
    }
}
