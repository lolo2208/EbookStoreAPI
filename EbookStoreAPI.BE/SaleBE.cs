using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.BE
{
    [Table("Sales")]
    public class SaleBE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSale { get; set; }

        [ForeignKey("CustomerNavigation")]
        public int Customer { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public virtual UserBE? CustomerNavigation { get; set; }
    }
}
