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

namespace EUserStoreAPI.DAL.Repositories
{
    public class UserDAL : IUserDAL
    {
        private readonly EbookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UserDAL(EbookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserBE> CreateUser(UserDTO user)
        {
            try
            {
                var UserBE = _mapper.Map<UserBE>(user);
                _context.Users.Add(UserBE);
                await _context.SaveChangesAsync();

                await _context.Entry(UserBE).ReloadAsync();

                return UserBE;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating role.", ex);
            }

        }

        public async Task<UserBE> DeleteUser(int idUser)
        {
            try
            {
                var toDeleteUser = await _context.Users.FindAsync(idUser);

                if (toDeleteUser == null)
                {
                    throw new Exception("User not found");
                }

                _context.Users.Remove(toDeleteUser);
                await _context.SaveChangesAsync();

                return toDeleteUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting user", ex);
            }
        }

        public async Task<UserBE> FindByAuthentication(UserDTO user)
        {
            try
            {

                if (user.Email != null && user.Password != null)
                {
                    var authUser = await _context.Users.Include(u => u.RoleNavigation).FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);

                    if(authUser != null)
                    {
                        return authUser;

                    }
                    else
                    {
                        throw new Exception("User Nor Found");
                    }

                }
                else
                {
                    throw new Exception("Bad Request");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting user", ex);
            }
        }

        public async Task<UserBE> FindById(int idUser)
        {
            try
            {
                var findedUser = await _context.Users.FindAsync(idUser);

                if (findedUser == null)
                {
                    throw new Exception("User not found");
                }

                return findedUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting user", ex);
            }
        }

        public async Task<List<UserBE>> GetAllUsersAsync()
        {
            if (_context.Users == null)
            {
                throw new Exception("No Users found");
            }
            return await _context.Users.Include(u => u.RoleNavigation).ToListAsync();
        }

        public async Task<UserBE> UpdateUser(UserDTO user)
        {
            try
            {
                var existingUser = await _context.Users.FindAsync(user.IdUser);
                var UserBE = _mapper.Map<UserBE>(user);

                if (existingUser == null)
                {
                    throw new Exception("User not found");
                }

                _context.Entry(existingUser).CurrentValues.SetValues(UserBE);
                await _context.SaveChangesAsync();

                await _context.Entry(existingUser).ReloadAsync();

                return existingUser;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating user", ex);
            }
        }
    }
}
