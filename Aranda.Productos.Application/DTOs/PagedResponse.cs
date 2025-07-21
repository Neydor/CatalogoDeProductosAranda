using System;
using System.Collections.Generic;

namespace Aranda.Productos.Application.DTOs
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Data { get; }
        public PaginationMetadata Metadata { get; }

        public PagedResponse(IEnumerable<T> data, int totalCount, int pageNumber, int pageSize)
        {
            Data = data;
            Metadata = new PaginationMetadata(totalCount, pageNumber, pageSize);
        }
    }

    public class PaginationMetadata
    {
        public int TotalCount { get; }
        public int PageSize { get; }
        public int CurrentPage { get; }
        public int TotalPages { get; }
        public bool HasNextPage => CurrentPage < TotalPages;
        public bool HasPreviousPage => CurrentPage > 1;

        public PaginationMetadata(int totalCount, int currentPage, int pageSize)
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }
} 