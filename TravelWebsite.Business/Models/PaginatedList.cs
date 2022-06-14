﻿namespace TravelWebsite.Business.Models
{
    public class PaginatedList
    {
        const int MaxPageSize = 30;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize { get { return _pageSize; } set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; } }
    }
}
