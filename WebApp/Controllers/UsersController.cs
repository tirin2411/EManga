using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using ViewModels.System.Users;
using ApiSer;
using Application.System.Users;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userApiClient;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        //private readonly IUserService _userApiClient;

        public UsersController(UserManager<AppUser> userManager,
            IUserService userService,
            IConfiguration configuration
            //IUserService userApiClient
            )
        {
            _userManager = userManager;
            _userApiClient = userService;
            _configuration = configuration;

            //_userApiClient = userApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var model = new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.Ho + " "+ user.Ten,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Dob = user.Dob,
                GioiTinh = user.GioiTinh
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _userApiClient.Authencate(request);
            if (result.ResultObj == null)
            {
                TempData["notice"] = "Username or password is incorrect.";
                return View();
            }

            var userPrincipal = this.ValidateToken(result.ResultObj);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };
            HttpContext.Session.SetString("Token", result.ResultObj);
            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        authProperties);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var sessions = HttpContext.Session.GetString("Token");
            var data = await _userApiClient.GetAll();
            return View(data);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _userApiClient.SignOut(HttpContext).Wait();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Password()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _userApiClient.Register(request);
            if (result.IsSuccessed)
            {
                TempData["register"] = "Register is unsuccessful.";
                return View();
            }
            TempData["registersuccess"] = "Register is successful.";
            return RedirectToAction("Index", "Home");
        }

        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
    }
}