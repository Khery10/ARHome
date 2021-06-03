
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ARHome.GenericSubDomain.Paging;

namespace ARHome.Infrastructure.Paging
{
    internal sealed class PagedList<T> : IPagedList<T>
    {
        public PagedList(int pageIndex, int pageSize, int totalCount, T[] items)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            Items = items;
        }
        
        public int PageIndex { get; }
        
        public int PageSize { get; }
        
        public int TotalCount { get; }

        public int TotalPages
        {
            get
            {
               var count = TotalCount / PageIndex;
               return TotalCount % PageIndex == 0
                   ? count
                   : count + 1;
            }
        } 
        public T[] Items { get; }
    }
}
