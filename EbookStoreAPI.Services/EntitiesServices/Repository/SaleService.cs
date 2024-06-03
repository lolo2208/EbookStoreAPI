using EbookStoreAPI.BE;
using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.EntitiesServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.Services.EntitiesServices.Repository
{
    public class SaleService : ISaleService
    {
        private readonly ISaleDAL _saleDAL;
        private readonly IBookService _bookService;
        private readonly ISaleDetailDAL _saleDetailDAL;

        public SaleService(ISaleDAL saleDAL, ISaleDetailDAL saleDetailDAL, IBookService bookService)
        {
            _saleDAL = saleDAL;
            _saleDetailDAL = saleDetailDAL;
            _bookService = bookService;
        }

        public async Task<SaleBE> GenerateSale(DetailedSaleDTO detailedSale)
        {
            try
            {
                var registeredSale = detailedSale.Sale;
                List<SaleDetailDTO> registeredDetail = detailedSale.Details;

                if (registeredSale != null && registeredDetail != null)
                {
                    // Registar la venta
                    registeredSale.CreatedAt = DateTime.Now;
                    registeredSale.TotalAmount = calculateTotalAmount(registeredDetail);

                    var registeredSaleBE = await _saleDAL.CreateSale(registeredSale);

                    foreach (var d in registeredDetail)
                    {
                        if (d.BookNavigation != null)
                        {
                            await UpdateBookStock(d.BookNavigation);
                            await RegisterSaleDetail(d, registeredSaleBE.IdSale);
                        }
                    }

                    return registeredSaleBE;
                }
                else
                {
                    throw new Exception("Sale null");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while registering sale", ex);
            }
        }

        public Task<List<SaleBE>> GetAllSales()
        {
            throw new NotImplementedException();
        }

        private decimal calculateTotalAmount(List<SaleDetailDTO> details)
        {
            decimal totalAmount = 0;
            details.ForEach(d =>
            {
                totalAmount += d.SubTotal ?? 0;
            });

            return totalAmount;
        }

        private async Task UpdateBookStock(BookDTO book)
        {
            try
            {

                book.AvailableUnits -= 1;
                var updatedBookBE = await _bookService.UpdateBook(book);
                _bookService.Detach(updatedBookBE);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating stock", ex);
            }
        }

        private async Task RegisterSaleDetail(SaleDetailDTO saleDetail, int idSale)
        {
            try
            {
                saleDetail.Sale = idSale;
                saleDetail.Book = saleDetail.BookNavigation.IdBook;
                saleDetail.BookNavigation = null;

                var newSaleDetail = await _saleDetailDAL.CreateSaleDetail(saleDetail);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while registering sale detail", ex);
            }
        }
    }
}
