using AutoMapper;
using EbookStoreAPI.BE;
using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.Authentication.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.Services.Authentication.Repository
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserDAL _userDAL;
        private readonly IShoppingCartDAL _shoppingCartDAL;

       
        public AuthenticationService(IUserDAL userDAL, IShoppingCartDAL shoppingCartDAL)
        {
            _userDAL = userDAL;
            _shoppingCartDAL = shoppingCartDAL;
        }
       
        

        public async Task<UserBE> AuthenticateUser(UserDTO user)
        {
            try
            {
                UserBE loggedUser = await _userDAL.FindByAuthentication(user);

                if (loggedUser == null)
                {
                    throw new Exception("User Nor Found");
                }
                return loggedUser;
            }
            catch (Exception ex)
            {
                throw new Exception("User Nor Found", ex);
            }
          
            throw new NotImplementedException();
        }

        public Task<UserBE> Login(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserBE> Register(UserDTO user)
        {
            try
            {
                var newUser = await _userDAL.CreateUser(user);
                if (newUser is not null)
                {
                    ShoppingCartDTO shopCart = new ShoppingCartDTO()
                    {
                        Customer = newUser.IdUser
                    };

                    var newShopCart = await _shoppingCartDAL.CreateShoppingCart(shopCart);

                    return newUser;

                }else
                {
                    throw new Exception("Error while registering user");
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error while registering user", ex);
            }
        }
    }
}
