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
    public class SaleDAL: ISaleDAL
    {
        private readonly EbookStoreDbContext _context;
        private readonly IMapper _mapper;

        public SaleDAL(EbookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SaleBE> CreateSale(SaleDTO sale)
        {
            try
            {
                var saleBE = _mapper.Map<SaleBE>(sale);
                _context.Sales.Add(saleBE);
                await _context.SaveChangesAsync();

                await _context.Entry(saleBE).ReloadAsync();

                return saleBE;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating Sale.", ex);
            }

        }

        public async Task<SaleBE> DeleteSale(int idSale)
        {
            try
            {
                var toDeleteSale = await _context.Sales.FindAsync(idSale);

                if (toDeleteSale == null)
                {
                    throw new Exception("Sale not found");
                }

                _context.Sales.Remove(toDeleteSale);
                await _context.SaveChangesAsync();

                return toDeleteSale;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting Sale", ex);
            }
        }

        public async Task<SaleBE> FindById(int idSale)
        {
            try
            {
                var findedSale = await _context.Sales.FindAsync(idSale);

                if (findedSale == null)
                {
                    throw new Exception("Sale not found");
                }

                return findedSale;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting Sale", ex);
            }
        }

        public async Task<List<SaleBE>> GetAllSalesAsync()
        {
            if (_context.Sales == null)
            {
                throw new Exception("No Sales found");
            }
            return await _context.Sales.ToListAsync();
        }

        public async Task<SaleBE> UpdateSale(SaleDTO sale)
        {
            try
            {
                var existingSale = await _context.Sales.FindAsync(sale.IdSale);
                var saleBE = _mapper.Map<SaleBE>(sale);

                if (existingSale == null)
                {
                    throw new Exception("Sale not found");
                }

                _context.Entry(existingSale).CurrentValues.SetValues(saleBE);
                await _context.SaveChangesAsync();

                await _context.Entry(existingSale).ReloadAsync();

                return existingSale;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating Sale", ex);
            }
        }

        public async Task<List<SaleBE>> FindByUser(int userId)
        {
            try
            {
                var findedSale = await _context.Sales.Include(s => s.CustomerNavigation)
                    .Where(s => s.Customer == userId)
                    .ToListAsync();

                if (findedSale == null)
                {
                    throw new Exception("Sale not found");
                }

                return findedSale;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting Sale", ex);
            }
        }
    }
}
