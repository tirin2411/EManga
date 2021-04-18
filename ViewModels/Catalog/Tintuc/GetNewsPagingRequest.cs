using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Common;

namespace ViewModels.Catalog.Tintuc
{
    public class GetNewsPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

    }
}
