using Microsoft.AspNetCore.Http;
using Post_EDU.Core.Models;
using Post_EDU.Core.UploadModels;
using System.Security.Claims;

namespace Post_EDU.Application.ServiceContracts
{
    public interface IAuthorizeService
    {
        public Task<ClaimsPrincipal?> SingInAsync(UserUpload model);
        public Task SingOutAsync(UserUpload model);
        public Task RegisterAsync(UserUpload model, string? pathImg);
    }
}
