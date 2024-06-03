using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DAL.Interfaces
{
    public interface IShoppingCartDetailDAL
    {
        Task<List<ShopCartDetailBE>> GetAllShoppingCartDetailsAsync();
        Task<List<ShopCartDetailBE>> GetCartDetailsByCartAsync(int shoppingCartId);
        Task<ShopCartDetailBE> CreateShoppingCartDetail(ShopCartDetailDTO shoppingCartDetail);
        Task<ShopCartDetailBE> UpdateShoppingCartDetail(ShopCartDetailDTO shoppingCartDetail);
        Task<ShopCartDetailBE> DeleteShoppingCartDetail(int idShopCartDetailId);
        Task<ShopCartDetailBE> FindById(int idShopCartDetailId);
    }
}
