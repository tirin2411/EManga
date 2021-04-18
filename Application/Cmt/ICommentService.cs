using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Cmt;
using ViewModels.Common;

namespace Application.Cmt
{
    public interface ICommentService
    {
        Task<List<CommentVM>> GetCmtByIdManga(int mangaId);
        Task<int> Create(Guid userId, int mangaId, CommentForm request);
        Task<ApiResult<bool>> Delete(int id);

    }
}
