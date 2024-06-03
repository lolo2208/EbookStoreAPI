using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DTO
{
    public class SaleDetailDTO
    {
        public int? IdSaleDetail { get; set; }

        public int? Sale { get; set; }

        public int? Book { get; set; }

        public decimal? SubTotal { get; set; }

        public  SaleDTO? SaleNavigation { get; set; }
        public  BookDTO? BookNavigation { get; set; }
    }
}
