using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DAL.Interfaces
{
    public interface ISaleDAL
    {
        Task<List<SaleBE>> GetAllSalesAsync();
        Task<SaleBE> CreateSale(SaleDTO sale);
        Task<SaleBE> UpdateSale(SaleDTO sale);
        Task<SaleBE> DeleteSale(int idSale);
        Task<SaleBE> FindById(int idSale);
        Task<List<SaleBE>> FindByUser(int idUser);
    }
}
