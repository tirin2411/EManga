using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Common;

namespace ViewModels.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}