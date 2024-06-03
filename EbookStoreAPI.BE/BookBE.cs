using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EbookStoreAPI.BE
{
    [Table("Books")]
    public class BookBE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBook { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required]
        [StringLength(100)]
        public string? Author { get; set; }

        [StringLength(1000)]
        public string? Sinopsis { get; set; }

        [StringLength(100)]
        public string? Editorial { get; set; }

        [Required]
        public int TotalUnits { get; set; }

        [Required]
        public int AvailableUnits { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? CoverImg { get; set; }
    }
}
