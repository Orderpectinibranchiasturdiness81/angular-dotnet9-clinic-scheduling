using Scheduling.Domain.Entity;
using Scheduling.Domain.Models.Request;
using Scheduling.Domain.Models.Response;

namespace Scheduling.Domain.Mapping
{
    public static class UserProfileMapping
    {
        public static UserProfile ToUserProfile(this UserProfileRequest request)
        {
            return new UserProfile(nameAr: request.NameAr,
                                   nameEn: request.NameEn,
                                   phoneNumber: request.PhoneNumber,
                                   description: request.Description);
        }

        public static UserProfileResponse FromUserProfile(this UserProfile entity)
        {
            var response =new UserProfileResponse();

            response.Id = entity.Id;
            response.NameAr = entity.NameAr;
            response.NameEn = entity.NameEn;
            response.PhoneNumber = entity.PhoneNumber;
            response.Description = entity.Description;

            return response;
        }
    }
}
