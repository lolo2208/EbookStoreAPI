using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DTO
{
    public class SaleDTO
    {
        public int? IdSale { get; set; }

        public int? Customer { get; set; }

        public decimal? TotalAmount { get; set; }

        public DateTime? CreatedAt { get; set; }

        public UserDTO? CustomerNavigation { get; set; }
    }
}
