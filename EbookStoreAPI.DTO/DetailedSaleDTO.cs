using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DTO
{
    public class DetailedSaleDTO
    {
        public SaleDTO? Sale { get; set; }
        public List<SaleDetailDTO>? Details { get; set; }
    }
}
