﻿using DataAccess.DTO;
using DataAccess.Entities;

namespace Business.Common.Interfaces
{
    public interface IPlaceService
    {
        Task<List<PlaceDTO>> Get();

        //Task<List<PlaceDTO>> GetAsysnc(int id);

        Task CreatePlace(PlaceDTO placeDto);

        Task<List<PlaceDTO>> SortDescending();

    }
}
