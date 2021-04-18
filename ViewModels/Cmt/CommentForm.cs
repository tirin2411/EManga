using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.Cmt
{
    public class CommentForm
    {
        public string CommentText { get; set; }
        public Status status { get; set; }
    }
}
