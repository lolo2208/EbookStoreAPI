using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.Services.EntitiesServices.Interfaces
{
    public interface ISaleService
    {
        Task<SaleBE> GenerateSale(DetailedSaleDTO detailedSale);
        Task<List<SaleBE>> GetAllSales();
    }
}
