using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Torc.Aguilar.BookLibrary.Models.Filters
{
    public class BookFilter
    {
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public string? Status { get; set; }
    }
}
