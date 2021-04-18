using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Common;
using ViewModels.System.Users;

namespace Application.System.Users
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAll();

        Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPaging(GetUserPagingRequest request);

        Task<ApiResult<UserViewModel>> GetById(Guid id);

        Task<ApiResult<string>> Authencate(LoginRequest request);

        Task<UserViewModel> GetCurrentUser(string username);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<bool> SignOut(HttpContext httpContext);

        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);

        Task<bool> ChangePassword(ChangePasswordRequest request);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
    }
}