using EbookStoreAPI.BE;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.EntitiesServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EbookStoreAPI.Controllers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public async Task<SaleBE> GenerateSale(DetailedSaleDTO detailedSale)
        {
            return await _saleService.GenerateSale(detailedSale);
        }
    }
}
