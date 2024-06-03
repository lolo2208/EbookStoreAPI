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
    public class SaleDetailDAL:ISaleDetailDAL
    {
        private readonly EbookStoreDbContext _context;
        private readonly IMapper _mapper;

        public SaleDetailDAL(EbookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SaleDetailBE> CreateSaleDetail(SaleDetailDTO saleDetail)
        {
            try
            {
                var saleDetailBE = _mapper.Map<SaleDetailBE>(saleDetail);
                _context.SaleDetails.Add(saleDetailBE);
                await _context.SaveChangesAsync();

                await _context.Entry(saleDetailBE).ReloadAsync();

                return saleDetailBE;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating SaleDetail.", ex);
            }

        }

        public async Task<SaleDetailBE> DeleteSaleDetail(int idSaleDetail)
        {
            try
            {
                var toDeleteSaleDetail = await _context.SaleDetails.FindAsync(idSaleDetail);

                if (toDeleteSaleDetail == null)
                {
                    throw new Exception("SaleDetail not found");
                }

                _context.SaleDetails.Remove(toDeleteSaleDetail);
                await _context.SaveChangesAsync();

                return toDeleteSaleDetail;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting SaleDetail", ex);
            }
        }

        public async Task<SaleDetailBE> FindById(int idSaleDetail)
        {
            try
            {
                var findedSaleDetail = await _context.SaleDetails.FindAsync(idSaleDetail);

                if (findedSaleDetail == null)
                {
                    throw new Exception("SaleDetail not found");
                }

                return findedSaleDetail;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting SaleDetail", ex);
            }
        }

        public async Task<List<SaleDetailBE>> GetAllSaleDetailsAsync()
        {
            if (_context.SaleDetails == null)
            {
                throw new Exception("No SaleDetails found");
            }
            return await _context.SaleDetails.ToListAsync();
        }

        public async Task<SaleDetailBE> UpdateSaleDetail(SaleDetailDTO saleDetail)
        {
            try
            {
                var existingSaleDetail = await _context.SaleDetails.FindAsync(saleDetail.IdSaleDetail);
                var saleDetailBE = _mapper.Map<SaleDetailBE>(saleDetail);

                if (existingSaleDetail == null)
                {
                    throw new Exception("SaleDetail not found");
                }

                _context.Entry(existingSaleDetail).CurrentValues.SetValues(saleDetailBE);
                await _context.SaveChangesAsync();

                await _context.Entry(existingSaleDetail).ReloadAsync();

                return existingSaleDetail;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating SaleDetail", ex);
            }
        }

        public async Task<List<SaleDetailBE>> FindBySale(int saleId)
        {
            try
            {
                var findedSaleDetail = await _context.SaleDetails.Include(s => s.BookNavigation)
                    .Where(s => s.Sale == saleId)
                    .ToListAsync();

                if (findedSaleDetail == null)
                {
                    throw new Exception("SaleDetail not found");
                }

                return findedSaleDetail;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting SaleDetail", ex);
            }
        }
    }
}
