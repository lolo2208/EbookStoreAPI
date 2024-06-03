using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.BE
{
    [Table("SaleDetails")]
    public class SaleDetailBE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSaleDetail { get; set; }

        [ForeignKey("SaleNavigation")]
        public int Sale { get; set; }

        [ForeignKey("BookNavigation")]
        public int Book { get; set; }

        [Required]
        public decimal SubTotal { get; set; }
        public virtual SaleBE? SaleNavigation { get; set; }
        public virtual BookBE? BookNavigation { get; set; }
    }
}
