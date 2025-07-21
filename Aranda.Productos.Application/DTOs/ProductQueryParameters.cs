using System;

namespace Aranda.Productos.Application.DTOs
{
    public class ProductQueryParameters
    {
        private const int MaxPageSize = 100;
        public string Filter { get; set; }
        public string SortBy { get; set; } = "nombre";
        public string SortOrder { get; set; } = "asc";

        private int _page = 1;
        public int Page
        {
            get => _page;
            set => _page = (value > 0) ? value : 1;
        }

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
} 