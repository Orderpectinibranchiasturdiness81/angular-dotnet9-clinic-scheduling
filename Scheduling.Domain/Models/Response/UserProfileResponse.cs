namespace Scheduling.Domain.Models.Response
{
    public class UserProfileResponse
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string? Description { get; set; }
        public string PhoneNumber { get; set; }
    }
}
