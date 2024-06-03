using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.Services.EntitiesServices.Interfaces
{
    public interface IShopCartService
    {
        Task<List<ShoppingCartBE>> GetAllShoppingCartsAsync();
        Task<ShoppingCartBE> CreateShoppingCart(ShoppingCartDTO shoppingCart);
        Task<ShoppingCartBE> UpdateShoppingCart(ShoppingCartDTO shoppingCart);
        Task<ShoppingCartBE> DeleteShoppingCart(int idShoppingCart);
        Task<ShoppingCartBE> FindShoppingCartById(int idShoppingCart);
        Task<ShoppingCartBE> FindShoppingCartByUser(int idUser);


        Task<List<ShopCartDetailBE>> GetAllShoppingCartDetailsAsync();
        Task<List<ShopCartDetailBE>> GetCartDetailsByCartAsync(int shoppingCartId);
        Task<ShopCartDetailBE> CreateShoppingCartDetail(ShopCartDetailDTO shoppingCartDetail);
        Task<ShopCartDetailBE> UpdateShoppingCartDetail(ShopCartDetailDTO shoppingCartDetail);
        Task<ShopCartDetailBE> DeleteShoppingCartDetail(int idShopCartDetailId);
        Task<ShopCartDetailBE> FindShoppingCartDetailById(int idShopCartDetailId);

        Task<List<ShopCartDetailBE>> finUserCartDetails(int idUser);
    }
}
