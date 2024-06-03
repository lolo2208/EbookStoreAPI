using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DAL.Interfaces
{
    public interface IShoppingCartDAL
    {
        Task<List<ShoppingCartBE>> GetAllShoppingCartsAsync();
        Task<ShoppingCartBE> CreateShoppingCart(ShoppingCartDTO shoppingCart);
        Task<ShoppingCartBE> UpdateShoppingCart(ShoppingCartDTO shoppingCart);
        Task<ShoppingCartBE> DeleteShoppingCart(int idShoppingCart);
        Task<ShoppingCartBE> FindById(int idShoppingCart);
        Task<ShoppingCartBE> FindByUser(int idUser);
    }
}
