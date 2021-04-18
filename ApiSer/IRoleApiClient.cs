using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Common;
using ViewModels.System.Roles;

namespace ApiSer
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleViewModel>>> GetAll();
    }
}