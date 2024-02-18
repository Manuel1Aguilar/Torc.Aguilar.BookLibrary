namespace Torc.Aguilar.BookLibrary.Models.Utilities
{
    public class PaginatedResult<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public List<T> Result { get; set; }
        public PaginatedResult(int page, int pageSize, int total, List<T> result)
        {
            Page = page;
            PageSize = pageSize;
            Total = total;
            Result = result;
        }
    }
}
