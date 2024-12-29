
namespace Scheduling.Domain.Models
{
    public class PagedDataDto<T>
    {
        public List<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
