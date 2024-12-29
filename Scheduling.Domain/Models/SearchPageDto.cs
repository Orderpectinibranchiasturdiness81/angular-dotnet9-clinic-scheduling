
namespace Scheduling.Domain.Models
{
    public class SearchPageDto<T>
    {
        public int Page { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public T Criteria { get; set; }
    }
}
