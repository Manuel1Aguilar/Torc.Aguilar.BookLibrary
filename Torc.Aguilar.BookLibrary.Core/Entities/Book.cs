using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Torc.Aguilar.BookLibrary.Core.Entities
{
    public class Book : BaseEntity<int>
    {
        [Column("title")]
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Column("first_name")]
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Column("total_copies")]
        [Required]
        public int TotalCopies { get; set; }
        [Column("copies_in_use")]
        [Required]
        public int CopiesInUse { get; set; }
        [Column("type")]
        [MaxLength(50)]
        public string Type { get; set; }
        [Column("isbn")]
        [MaxLength(80)]
        public string ISBN { get; set; }
        [Column("category")]
        [MaxLength(50)]
        public string Category { get; set; }

        [Column("status")]
        [MaxLength(15)]
        public string Status { get; set; }
    }
}
