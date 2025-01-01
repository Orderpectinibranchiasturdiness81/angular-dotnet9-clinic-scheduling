using Microsoft.AspNetCore.Mvc;
using Scheduling.Domain.IServices;
using Scheduling.Domain.Models.Filter;
using Scheduling.Domain.Models.Response;
using Scheduling.Domain.Models;
using Scheduling.Domain.Models.Request;

namespace Scheduling.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _service;

        public UserProfileController(IUserProfileService service)
        {
            _service = service;
        }
        //---------------------------------------------**
        [HttpPost("search")]
        public async Task<PagedDataDto<UserProfileResponse>> Search(SearchPageDto<UserProfileFilter> searchPageDto)
        {
            return await _service.Search(searchPageDto);
        }

        [HttpGet("{id}")]
        public async Task<UserProfileResponse> GetById(int id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task Add(UserProfileRequest request)
        {
            await _service.Add(request);
        }

        [HttpPut]
        public async Task Update(UserProfileRequest request)
        {
            await _service.Update(request);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
