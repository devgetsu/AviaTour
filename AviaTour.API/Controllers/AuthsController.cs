using AviaTour.Application.UseCases.AuthService;
using AviaTour.Domain.Entities.Auth;
using AviaTour.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AviaTour.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthService _authService;
        private readonly Random _random;

        public AuthsController(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager, IAuthService authService, Random random)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _random = random;
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDTO register)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        throw new Exception();
        //    }

        //    var user = new User()
        //    {
        //        UserName = register.Name + register.Surname,
        //        Name = register.Name,
        //        Surname = register.Surname,
        //        Email = register.Email,
        //        Password = register.Password,
        //        PhoneNumber = register.PhoneNumber,
        //        Role = "User"
        //    };

        //    var result = await _userManager.CreateAsync(user, register.Password);

        //    if (!result.Succeeded)
        //        throw new Exception();

        //    await _userManager.AddToRoleAsync(user, "User");

        //    return Ok(new ResponseModel()
        //    {
        //        IsSuccess = true,
        //        Message = "Successfully created",
        //        StatusCode = 201
        //    });

        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginDTO login)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        throw new Exception();
        //    }
        //    var user = await _userManager.FindByEmailAsync(login.Email);

        //    if (user == null)
        //    {
        //        return BadRequest(new TokenDTO()
        //        {
        //            Message = "Email Not Found!",
        //            isSuccess = false,
        //            Token = ""
        //        });
        //    }

        //    var checker = await _userManager.CheckPasswordAsync(user, login.Password);
        //    if (!checker)
        //    {
        //        return BadRequest(new TokenDTO()
        //        {
        //            Message = "Password do not match!",
        //            isSuccess = false,
        //            Token = ""
        //        });
        //    }

        //    var token = _authService.GenerateToken(user);

        //    return Ok(new TokenDTO()
        //    {
        //        Token = token,
        //        isSuccess = true,
        //        Message = "Success"
        //    });

        //}

        //[HttpGet]
        //public async Task<List<User>> GetAll()
        //{
        //    var result = await _userManager.Users.ToListAsync();

        //    return result;
        //}



        //[HttpGet]
        //public async Task<User> GetById(Guid id)
        //{
        //    var result = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

        //    if (result == null)
        //        throw new Exception();

        //    return result;
        //}


        [HttpPost("ExternalLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLogin([FromBody] ExternalLoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                user = new User()
                {
                    Id = _random.NextInt64(),
                    UserName = model.FirstName + model.LastName,
                    Name = model.FirstName,
                    Surname = model.LastName,
                    Email = model.Email,
                    PhotoUrl = model.PhotoUrl,
                    Role = "User"
                };

                await _userManager.CreateAsync(user);

                await _userManager.AddToRoleAsync(user, "User");
            }

            var info = new UserLoginInfo(model.Provider, model.ProviderKey, user.UserName);

            await _userManager.AddLoginAsync(user, info);

            await _signInManager.SignInAsync(user, false);

            var token = _authService.GenerateToken(user);

            return Ok(new TokenDTO()
            {
                Token = token,
                isSuccess = true,
                Message = "Success"
            });
        }
    }
}
