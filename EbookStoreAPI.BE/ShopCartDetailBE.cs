using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.BE
{
    [Table("ShopCartDetails")]
    public class ShopCartDetailBE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdShopCartDetail { get; set; }

        [ForeignKey("ShoppingCartNavigation")]
        public int ShoppingCart { get; set; }

        [ForeignKey("BookNavigation")]
        public int Book { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        public virtual ShoppingCartBE? ShoppingCartNavigation { get; set; }
        public virtual BookBE? BookNavigation { get; set; }
    }
}
