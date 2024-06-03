using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.BE
{
    [Table("ShoppingCarts")]
    public class ShoppingCartBE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdShopCart { get; set; }

        [ForeignKey("CustomerNavigation")]
        public int Customer { get; set; }

        public virtual UserBE? CustomerNavigation { get; set; }
    }
}
