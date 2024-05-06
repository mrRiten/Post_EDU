using Post_EDU.Application.RepositoryContracts;
using Post_EDU.Application.ServiceContracts;
using Post_EDU.Core.UploadModels;
using System.Security.Claims;
using Post_EDU.Core.Models;

namespace Post_EDU.Infrastructure.Services
{
    public class AuthorizeService(IUserRepository userRepository) : IAuthorizeService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task RegisterAsync(UserUpload model, string? pathImg)
        {
            var user = new User
            {
                Name = model.Name,
                Description = "No Info",
                Password = model.Password,

                DateOfRegister = DateTime.Now,
                LastLogin = DateTime.Now,

                RoleId = 2,

                PathImg = pathImg
            };

            await _userRepository.CreateAsync(user);
        }

        public async Task<ClaimsPrincipal?> SingInAsync(UserUpload model)
        {
            var user = await _userRepository.GetByNamePasswordAsync(model.Name, model.Password);
            if (user == null) { return null; }

            await _userRepository.UpdateUserLoginTimeAsync(user.IdUser, DateTime.Now);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.RoleName)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return claimsPrincipal;
        }

        public Task SingOutAsync(UserUpload model)
        {
            
        }
    }
}
