using Scheduling.Domain.Models.Filter;
using Scheduling.Domain.Models.Response;
using Scheduling.Domain.Models;
using Scheduling.Domain.Models.Request;

namespace Scheduling.Domain.IServices
{
    public interface IUserProfileService
    {
        Task<PagedDataDto<UserProfileResponse>> Search(SearchPageDto<UserProfileFilter> searchPageDto);
        Task<UserProfileResponse> GetById(int id);
        Task Add(UserProfileRequest request);
        Task Update(UserProfileRequest request);
        Task Delete(int id);
    }
}
