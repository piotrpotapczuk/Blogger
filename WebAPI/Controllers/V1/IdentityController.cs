using Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Wrappers;

namespace WebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public IdentityController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var userFound = await _userManager.FindByNameAsync(registerModel.Username);

            if (userFound != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response<bool>
                {
                    Succeed = false,
                    Message = "User already exists !"
                });

            }

            ApplicationUser newUser = new ApplicationUser
            {
                UserName = registerModel.Username,
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, registerModel.Password);
            if (!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response<bool>
                {
                    Succeed = false,
                    Message = "User creation failed! Please check user details and try agian.",
                    Errors = identityResult.Errors.Select(err => err.Description)
                });
            }

            return Ok(new Response<bool>
            {
                Succeed = true,
                Message = "User created successfully!"
            });
        }

    }
}
