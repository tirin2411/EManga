using Data.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ViewModels.Cmt;
using Data.Entities;
using ViewModels.Common;
using Utilities.Exceptions;

namespace Application.Cmt
{
    public class CommentService : ICommentService
    {
        private readonly MnDbContext _context;

        public CommentService(MnDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Guid userId, int mangaId, CommentForm request)
        {
            var news = new MComment()
            {
                MangaId = mangaId,
                NoiDung = request.CommentText,
                NgayComment = DateTime.Now,
                Status = Data.Enums.Status.Active,
                UserId = userId
            };
            _context.MComments.Add(news);
            await _context.SaveChangesAsync();
            return news.Id;
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var manga = await _context.MComments.FindAsync(id);
            if (manga == null) throw new FMNException($"Cannot find a news: {id}");
            _context.MComments.Remove(manga);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<List<CommentVM>> GetCmtByIdManga(int mangaId)
        {
            var query = from wi in _context.MComments
                        join mn in _context.Mangas on wi.MangaId equals mn.Id
                        join u in _context.AppUsers on wi.UserId equals u.Id
                        select new { wi, mn, u };
            
            var data = await query.Where(c => c.wi.MangaId == mangaId).Select(x => new CommentVM()
            {
                UserId = x.u.Id,
                MangaId = x.mn.Id,
                UserName = x.u.Ten,
                CommentText = x.wi.NoiDung,
                CreatedOn = x.wi.NgayComment,
                Status = x.wi.Status
            }).ToListAsync();
        
            return data;
        }
    }
}
