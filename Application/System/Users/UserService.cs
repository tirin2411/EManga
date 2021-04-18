using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utilities.Exceptions;
using ViewModels.System.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using Data.EF;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Linq;
using ViewModels.Common;

namespace Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly MnDbContext _context;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager, IConfiguration config, MnDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _context = context;
        }

        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return new ApiErrorResult<string>("Tài khoản không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Đăng nhập không đúng");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Surname,user.Ho),
                new Claim(ClaimTypes.GivenName,user.Ten),
                new Claim("displayName", $"{user.Ho} {user.Ten}"),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }

            user = new AppUser()
            {
                Ho = request.Ho,
                Ten = request.Ten,
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Đăng ký không thành công");
        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Ho = request.Ho;
            user.Ten = request.Ten;
            user.Dob = request.Dob;
            user.GioiTinh = request.GioiTinh;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }

        public async Task<bool> ChangePassword(ChangePasswordRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (request.UserName == null)
            {
                throw new FMNException($"Cannot find an user with UserName {request.UserName}");
            }
            var result = await _userManager.ChangePasswordAsync(user, request.Password, request.newPassword);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> SignOut(HttpContext httpContext)
        {
            await _signInManager.SignOutAsync();
            await httpContext.SignOutAsync(new AuthenticationProperties
            { IsPersistent = false });
            return true;
        }

        public async Task<UserViewModel> GetCurrentUser(string username)
        {
            var user = await _context.AppUsers.FindAsync(username);
            var userViewModel = new UserViewModel()
            {
                //Id = user.Id,
                UserName = user.UserName,
                //Ho = user.Ho,
                //Ten = user.Ten,
                //Dob = user.Dob,
                //GioiTinh = user.GioiTinh,
                //Email = user.Email,
                //PhoneNumber = user.PhoneNumber,
            };
            return userViewModel;
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            return await _context.AppUsers.Select(i => new UserViewModel()
            {
                Id = i.Id,
                Ho = i.Ho,
                Ten = i.Ten,
                UserName = i.UserName,
                Dob = i.Dob,
                GioiTinh = i.GioiTinh,
                Email = i.Email,
                PhoneNumber = i.PhoneNumber
            }).ToListAsync();
        }

        public async Task<ApiResult<UserViewModel>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserViewModel>("User không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userViewModel = new UserViewModel()
            {
                FullName = user.Ho + " " + user.Ten,
                Ho = user.Ho,
                Ten = user.Ten,
                Dob = user.Dob,
                GioiTinh = user.GioiTinh,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Id = user.Id,
                Roles = roles
            };
            return new ApiSuccessResult<UserViewModel>(userViewModel);
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return new ApiSuccessResult<bool>();

            return new ApiErrorResult<bool>("Xóa không thành công");
        }

        public async Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.UserName.Contains(request.Keyword)
                 || x.PhoneNumber.Contains(request.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserViewModel()
                {
                    Id = x.Id,
                    Ho = x.Ho,
                    Ten = x.Ten,
                    UserName = x.UserName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<UserViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<UserViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại");
            }
            var removedRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
            foreach (var roleName in removedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }
            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            var addedRoles = request.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
            foreach (var roleName in addedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == false)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }

            return new ApiSuccessResult<bool>();
        }
    }
}