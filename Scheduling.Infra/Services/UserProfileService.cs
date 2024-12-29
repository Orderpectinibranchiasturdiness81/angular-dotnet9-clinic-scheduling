using Scheduling.Domain.Entity;
using Scheduling.Domain.IRepositories;
using Scheduling.Domain.IServices;
using Scheduling.Domain.Mapping;
using Scheduling.Domain.Models;
using Scheduling.Domain.Models.Filter;
using Scheduling.Domain.Models.Request;
using Scheduling.Domain.Models.Response;
using System.Linq.Expressions;

namespace Scheduling.Infra.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IRepository<UserProfile> _repository;

        public UserProfileService(IRepository<UserProfile> repository)
        {
            _repository = repository;
        }
        //---------------------------------------------**
        public async Task<PagedDataDto<UserProfileResponse>> Search(SearchPageDto<UserProfileFilter> searchPageDto)
        {
            Expression<Func<UserProfile, bool>> predicate = x =>
            (
                string.IsNullOrEmpty(searchPageDto.Criteria.Name) ||
                x.NameEn.Trim().ToUpper().Contains(searchPageDto.Criteria.Name.Trim().ToUpper()) ||
                x.NameAr.Trim().ToUpper().Contains(searchPageDto.Criteria.Name.Trim().ToUpper())
            ) &&
            (
                string.IsNullOrEmpty(searchPageDto.Criteria.PhoneNumber) ||
                x.PhoneNumber.Trim().ToUpper().Contains(searchPageDto.Criteria.PhoneNumber.Trim().ToUpper())
            );

            var userProfiles = await _repository.PageAsync(predicate: predicate,
                                                           pageIndex: searchPageDto.PageIndex,
                                                           pageSize: searchPageDto.PageSize);

            var result = new PagedDataDto<UserProfileResponse>()
            {
                Data = userProfiles.Data.Select(userProfile => userProfile.FromUserProfile()).ToList(),
                TotalCount = userProfiles.TotalCount
            };

            return result;
        }

        public async Task<UserProfileResponse> GetById(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid ID");

            var userProfileDB = await _repository.GetByIdAsync(id);

            if (userProfileDB is null)
                throw new Exception("User profile not found");

            return userProfileDB.FromUserProfile();
        }

        public async Task Add(UserProfileRequest request)
        {
            if (await _repository.AnyAsync(x => request.PhoneNumber.Trim().ToUpper() == x.PhoneNumber.Trim().ToUpper()))
                throw new Exception("Phone number already exists");

            if (await _repository.AnyAsync(x => request.NameAr == x.NameAr || request.NameEn == x.NameEn))
                throw new Exception("Name already exists");

            await _repository.AddAsync(request.ToUserProfile());
        }

        public async Task Update(UserProfileRequest request)
        {
            if (!request.Id.HasValue || request.Id.Value <= 0)
                throw new Exception("Invalid ID");

            if (await _repository.AnyAsync(x => x.Id != request.Id.Value && request.PhoneNumber.Trim().ToUpper() == x.PhoneNumber.Trim().ToUpper()))
                throw new Exception("Phone number already exists");

            if (await _repository.AnyAsync(x => x.Id != request.Id.Value && request.NameAr == x.NameAr || request.NameEn == x.NameEn))
                throw new Exception("Name already exists");

            var userProfileDB = await _repository.GetByIdAsync(request.Id.Value);

            if (userProfileDB is null)
                throw new Exception("User profile not found");

            userProfileDB.Update(nameAr: request.NameAr,
                                 nameEn: request.NameEn,
                                 phoneNumber: request.PhoneNumber,
                                 description: request.Description);
        }

        public async Task Delete(int id)
        {
            if (id <= 0)
                throw new Exception("Invalid ID");

            var userProfileDB = await _repository.GetByIdAsync(id);

            if (userProfileDB is null)
                throw new Exception("User profile not found");

            userProfileDB.Delete();
        }
    }
}
