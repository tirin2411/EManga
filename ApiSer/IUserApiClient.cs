using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Common;
using ViewModels.System.Users;

namespace ApiSer
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<List<UserViewModel>> GetAll();

        Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPagings(GetUserPagingRequest request);

        Task<ApiResult<bool>> RegisterUser(RegisterRequest request);

        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);

        Task<ApiResult<UserViewModel>> GetById(Guid id);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
        Task<ApiResult<bool>> SignOut(HttpContext httpContext);

    }
}