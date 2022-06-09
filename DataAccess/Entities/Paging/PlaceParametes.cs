﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelWebsite.DataAccess.Entities.Paging
{
    public class PlaceParametes
    {
        const int MaxPageSize = 30;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        { get { return _pageSize; } set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; } }
    }
}
