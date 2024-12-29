using Common;

namespace Scheduling.Domain.Entity
{
    public class UserProfile : DomainEntity
    {
        protected UserProfile() { }
        public UserProfile(string nameAr, string nameEn, string phoneNumber, string? description = null)
        {
            Validate(nameAr, nameEn, phoneNumber);
            NameAr = nameAr;
            NameEn = nameEn;
            PhoneNumber = phoneNumber;
            Description = description;
        }
        public int Id { get; set; }
        public string NameAr { get; private set; } 
        public string NameEn { get; private set; }
        public string? Description { get; private set; }
        public string PhoneNumber { get; private set; }

        //-----------------------------------------------------------------**

        public void Update(string nameAr, string nameEn, string phoneNumber, string? description = null)
        {
            Validate(nameAr, nameEn, phoneNumber);
            NameAr = nameAr;
            NameEn = nameEn;
            PhoneNumber = phoneNumber;
            Description = description;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        private void Validate(string nameAr, string nameEn, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(nameAr))
                throw new ArgumentNullException(nameof(nameAr), "Name-Ar cannot be null or empty");

            if (string.IsNullOrWhiteSpace(nameEn))
                throw new ArgumentNullException(nameof(nameEn), "Name-En cannot be null or empty");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentNullException(nameof(phoneNumber), "Phone-Number cannot be null or empty");
        }
    }
}
