using Hubtel.Vault.Api.Models;
using Hubtel.Vault.Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hubtel.Vault.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<WalletUser> _userManager;
        public AuthController(
            IAuthenticationService authenticationService,
            UserManager<WalletUser> userManager)
        {
            _authenticationService= authenticationService;
            _userManager = userManager;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromForm] SignUpModel model)
        {
            if (ModelState.IsValid)
            {

                // Validate model and create a new user

                var user = new WalletUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                };

                // authenticate user
                var existingUser = await _authenticationService.AuthenticateUser(model.Email, model.Password);

                if (existingUser != null)
                {
                    return BadRequest("User with the provided email already exists");
                }

                // create user
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Member");
                    var token = await _authenticationService.GenerateToken(user);
                    return Ok(new {token});
                }
                else
                {
                    return BadRequest(result?.Errors?.FirstOrDefault()?.Description);
                }
            }
            return BadRequest(ModelState);          
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            //authenticating user
            var user = await _authenticationService.AuthenticateUser(model.Email, model.Password);
            if (user != null)
            {
                var token = await _authenticationService.GenerateToken(user);
                return Ok(new {token});
            }

            return BadRequest("Invalid credentials");
        }
    }
}
