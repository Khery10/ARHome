using System.Collections.Generic;

namespace ARHome.GenericSubDomain.Paging
{
    public interface IPagedList<out T>
    {
        int PageIndex { get; }
        
        int PageSize { get; }
        
        int TotalCount { get; }
        
        int TotalPages { get; }

        T[] Items { get; }
    }
}
