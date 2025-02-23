namespace Scheduling.Domain.Models.Response
{
    public class UserProfileResponse
    {
        public int Id { get; set; }
        public string NameAr { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
