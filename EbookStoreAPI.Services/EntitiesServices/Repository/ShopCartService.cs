using EbookStoreAPI.BE;
using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DAL.Repositories;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.EntitiesServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.Services.EntitiesServices.Repository
{
    public class ShopCartService : IShopCartService
    {
        private readonly IShoppingCartDAL _shopppingCartDAL;
        private readonly IShoppingCartDetailDAL _shopppingCartDetailDAL;

        public ShopCartService(IShoppingCartDetailDAL shopppingCartDetail, IShoppingCartDAL shoppingCartDAL)
        {
            _shopppingCartDetailDAL = shopppingCartDetail;
            _shopppingCartDAL = shoppingCartDAL;
        }

        public async Task<ShoppingCartBE> CreateShoppingCart(ShoppingCartDTO shoppingCart)
        {
            return await _shopppingCartDAL.CreateShoppingCart(shoppingCart);
        }

        public async Task<ShopCartDetailBE> CreateShoppingCartDetail(ShopCartDetailDTO shoppingCartDetail)
        {
            return await _shopppingCartDetailDAL.CreateShoppingCartDetail(shoppingCartDetail);
        }

        public async Task<ShoppingCartBE> DeleteShoppingCart(int idShoppingCart)
        {
            return await _shopppingCartDAL.DeleteShoppingCart(idShoppingCart);
        }

        public async Task<ShopCartDetailBE> DeleteShoppingCartDetail(int idShopCartDetailId)
        {
            return await _shopppingCartDetailDAL.DeleteShoppingCartDetail(idShopCartDetailId);
        }

        public async Task<ShoppingCartBE> FindShoppingCartById(int idShoppingCart)
        {
            return await _shopppingCartDAL.FindById(idShoppingCart);
        }

        public async Task<ShoppingCartBE> FindShoppingCartByUser(int idUser)
        {
            return await _shopppingCartDAL.FindByUser(idUser);
        }

        public async Task<ShopCartDetailBE> FindShoppingCartDetailById(int idShopCartDetailId)
        {
            return await _shopppingCartDetailDAL.FindById(idShopCartDetailId);
        }

        public async Task<List<ShopCartDetailBE>> GetAllShoppingCartDetailsAsync()
        {
            return await _shopppingCartDetailDAL.GetAllShoppingCartDetailsAsync();
        }

        public async Task<List<ShoppingCartBE>> GetAllShoppingCartsAsync()
        {
            return await _shopppingCartDAL.GetAllShoppingCartsAsync();
        }

        public async Task<List<ShopCartDetailBE>> GetCartDetailsByCartAsync(int shoppingCartId)
        {
            return await _shopppingCartDetailDAL.GetCartDetailsByCartAsync(shoppingCartId);
        }

        public async Task<ShoppingCartBE> UpdateShoppingCart(ShoppingCartDTO shoppingCart)
        {
            return await _shopppingCartDAL.UpdateShoppingCart(shoppingCart);
        }

        public async Task<ShopCartDetailBE> UpdateShoppingCartDetail(ShopCartDetailDTO shoppingCartDetail)
        {
            return await _shopppingCartDetailDAL.UpdateShoppingCartDetail(shoppingCartDetail);
        }

        public async Task<List<ShopCartDetailBE>> finUserCartDetails(int idUser)
        {
            try
            {
                var cart = await _shopppingCartDAL.FindByUser(idUser);
                var cartDetail = await _shopppingCartDetailDAL.GetCartDetailsByCartAsync(cart.IdShopCart);

                return cartDetail;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while loading detail", ex);
            }
        }
    }
}
