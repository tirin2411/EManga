using System;
using System.Collections.Generic;
using System.Text;
using ViewModels.Common;

namespace ViewModels.Catalog.Khuyenmai
{
    public class GetDiscountPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
