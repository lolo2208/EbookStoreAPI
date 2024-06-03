using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbookStoreAPI.DTO
{
    public class BookDTO
    {
        public int? IdBook { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Sinopsis { get; set; }
        public string? Editorial { get; set; }
        public int? TotalUnits { get; set; }
        public int? AvailableUnits { get; set; }
        public decimal? Price { get; set; }
        public string? CoverImg { get; set; }
    }
}
