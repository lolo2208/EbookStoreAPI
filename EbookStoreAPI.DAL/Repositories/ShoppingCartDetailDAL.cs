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
    public class ShoppingCartDetailDAL: IShoppingCartDetailDAL
    {
        private readonly EbookStoreDbContext _context;
        private readonly IMapper _mapper;

        public ShoppingCartDetailDAL(EbookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ShopCartDetailBE> CreateShoppingCartDetail(ShopCartDetailDTO shopCartDetail)
        {
            try
            {
                var shopCartDetailBE = _mapper.Map<ShopCartDetailBE>(shopCartDetail);
                _context.ShopCartDetails.Add(shopCartDetailBE);
                await _context.SaveChangesAsync();

                await _context.Entry(shopCartDetailBE).ReloadAsync();

                return shopCartDetailBE;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating shopping cart detail.", ex);
            }

        }

        public async Task<ShopCartDetailBE> DeleteShoppingCartDetail(int idShopCartDetail)
        {
            try
            {
                var toDeleteShopCartDetail = await _context.ShopCartDetails
                    .Include(s => s.BookNavigation)
                    .FirstOrDefaultAsync(s => s.IdShopCartDetail == idShopCartDetail);

                if (toDeleteShopCartDetail == null)
                {
                    throw new Exception("Shopping cart detail not found");
                }

                _context.ShopCartDetails.Remove(toDeleteShopCartDetail);
                await _context.SaveChangesAsync();

                return toDeleteShopCartDetail;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting shopping cart detail", ex);
            }
        }

        public async Task<ShopCartDetailBE> FindById(int idShopCartDetail)
        {
            try
            {
                var findedShopCartDetail = await _context.ShopCartDetails
                    .Include(s => s.BookNavigation)
                    .FirstOrDefaultAsync(s => s.IdShopCartDetail == idShopCartDetail);

                if (findedShopCartDetail == null)
                {
                    throw new Exception("Shopping cart detail not found");
                }

                return findedShopCartDetail;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while finding shopping cart detail", ex);
            }
        }

        public async Task<List<ShopCartDetailBE>> GetAllShoppingCartDetailsAsync()
        {
            if (_context.ShopCartDetails == null)
            {
                throw new Exception("No shopping cart detail found");
            }
            return await _context.ShopCartDetails.ToListAsync();
        }

        public async Task<ShopCartDetailBE> UpdateShoppingCartDetail(ShopCartDetailDTO shopCartDetail)
        {
            try
            {
                var existingShopCartDetail = await _context.ShopCartDetails
                    .Include(s => s.BookNavigation)
                    .FirstOrDefaultAsync(s => s.ShoppingCart == shopCartDetail.ShoppingCart && s.Book == shopCartDetail.Book);
                var shopCartDetailBE = _mapper.Map<ShopCartDetailBE>(shopCartDetail);

                if (existingShopCartDetail == null)
                {
                    throw new Exception("Shopping cart detail not found");
                }

                _context.Entry(existingShopCartDetail).CurrentValues.SetValues(shopCartDetailBE);
                await _context.SaveChangesAsync();

                await _context.Entry(existingShopCartDetail).ReloadAsync();

                return existingShopCartDetail;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating shopping cart detail", ex);
            }
        }

        public async Task<List<ShopCartDetailBE>> GetCartDetailsByCartAsync(int shopCartId)
        {
            try
            {
                var shopCartDetails = await _context.ShopCartDetails
                    .Include(s => s.BookNavigation)
                    .Where(s => s.ShoppingCart == shopCartId)
                    .ToListAsync();

                return shopCartDetails;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating shopping cart detail", ex);
            }
        }
    }
}
