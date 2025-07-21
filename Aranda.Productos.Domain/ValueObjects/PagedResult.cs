using System.Collections.Generic;

namespace Aranda.Productos.Domain.ValueObjects
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; }
        public int TotalCount { get; }

        public PagedResult(IEnumerable<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
    }
} 