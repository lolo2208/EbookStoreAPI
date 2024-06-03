using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DTO
{
    public class ShopCartDetailDTO
    {
        public int? IdShopCartDetail { get; set; }
        public int? ShoppingCart { get; set; }

        public int? Book { get; set; }

        public decimal? SubTotal { get; set; }

        public virtual ShoppingCartDTO? ShoppingCartNavigation { get; set; }
        public virtual BookDTO? BookNavigation { get; set; }
    }
}
