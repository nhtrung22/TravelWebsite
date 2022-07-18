﻿using TravelWebsite.Business.Models.Commands;
using TravelWebsite.Business.Models.DTO;

namespace TravelWebsite.Business.Services
{
    public interface IAdminService
    {
        Task<StatisticsDTO> GetStatistics();
    }
}