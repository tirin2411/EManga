using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Cmt
{
    public class CommentVM
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CommentText { get; set; }
        public Status Status { get; set; }
        public int MangaId { get; set; }
    }
}
