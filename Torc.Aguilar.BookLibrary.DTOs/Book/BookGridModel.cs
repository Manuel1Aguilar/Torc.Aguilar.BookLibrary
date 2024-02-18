using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Torc.Aguilar.BookLibrary.Models.DTOs
{
    public class BookGridModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public string Type { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string AvailableCopies
        {
            get
            {
                if (TotalCopies > 0)
                {
                    int available = TotalCopies - CopiesInUse;
                    return $"{available}/{TotalCopies}";
                }
                else
                {
                    return "N/A"; 
                }
            }
        }
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
    }
}
