using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DTO
{
    public class ShoppingCartDTO
    {
        public int? IdShopCart { get; set; }

        public int? Customer { get; set; }

        public UserDTO? CustomerNavigation { get; set; }
    }
}
