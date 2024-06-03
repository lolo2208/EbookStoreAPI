using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DAL.Interfaces
{
    public interface ISaleDetailDAL
    {
        Task<List<SaleDetailBE>> GetAllSaleDetailsAsync();
        Task<SaleDetailBE> CreateSaleDetail(SaleDetailDTO saleDetail);
        Task<SaleDetailBE> UpdateSaleDetail(SaleDetailDTO saleDetail);
        Task<SaleDetailBE> DeleteSaleDetail(int idSaleDetail);
        Task<SaleDetailBE> FindById(int idSaleDetail);
        Task<List<SaleDetailBE>> FindBySale(int idSale);
    }
}
