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
    public class ShoppingCartDAL : IShoppingCartDAL
    {
        private readonly EbookStoreDbContext _context;
        private readonly IMapper _mapper;

        public ShoppingCartDAL(EbookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShoppingCartBE> CreateShoppingCart(ShoppingCartDTO shoppingCart)
        {
            try
            {
                var ShoppingCartBE = _mapper.Map<ShoppingCartBE>(shoppingCart);
                _context.ShoppingCarts.Add(ShoppingCartBE);
                await _context.SaveChangesAsync();

                await _context.Entry(ShoppingCartBE).ReloadAsync();

                return ShoppingCartBE;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating shoppingCart.", ex);
            }

        }

        public async Task<ShoppingCartBE> DeleteShoppingCart(int idShoppingCart)
        {
            try
            {
                var toDeleteShoppingCart = await _context.ShoppingCarts.FindAsync(idShoppingCart);

                if (toDeleteShoppingCart == null)
                {
                    throw new Exception("ShoppingCart not found");
                }

                _context.ShoppingCarts.Remove(toDeleteShoppingCart);
                await _context.SaveChangesAsync();

                return toDeleteShoppingCart;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting shoppingCart", ex);
            }
        }

        public async Task<ShoppingCartBE> FindById(int idShoppingCart)
        {
            try
            {
                var findedShoppingCart = await _context.ShoppingCarts.FindAsync(idShoppingCart);

                if (findedShoppingCart == null)
                {
                    throw new Exception("ShoppingCart not found");
                }

                return findedShoppingCart;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting shoppingCart", ex);
            }
        }

        public async Task<List<ShoppingCartBE>> GetAllShoppingCartsAsync()
        {
            if (_context.ShoppingCarts == null)
            {
                throw new Exception("No shoppingCarts found");
            }
            return await _context.ShoppingCarts.ToListAsync();
        }

        public async Task<ShoppingCartBE> UpdateShoppingCart(ShoppingCartDTO shoppingCart)
        {
            try
            {
                var existingShoppingCart = await _context.ShoppingCarts.FindAsync(shoppingCart.IdShopCart);
                var ShoppingCartBE = _mapper.Map<ShoppingCartBE>(shoppingCart);

                if (existingShoppingCart == null)
                {
                    throw new Exception("ShoppingCart not found");
                }

                _context.Entry(existingShoppingCart).CurrentValues.SetValues(ShoppingCartBE);
                await _context.SaveChangesAsync();

                await _context.Entry(existingShoppingCart).ReloadAsync();

                return existingShoppingCart;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating shoppingCart", ex);
            }
        }

        public async Task<ShoppingCartBE> FindByUser(int userId)
        {
            try
            {
                var findedShoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(c => c.Customer == userId);

                if (findedShoppingCart == null)
                {
                    throw new Exception("ShoppingCart not found");
                }

                return findedShoppingCart;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting shoppingCart", ex);
            }
        }
    }
}
