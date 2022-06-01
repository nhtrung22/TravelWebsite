﻿using AutoMapper;
using TravelWebsite.Business.Common.Interfaces;
using TravelWebsite.DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using TravelWebsite.Business.Common.Interfaces;

namespace TravelWebsite.Controllers
{
    [Route("api/place")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;
        public PlaceController(IPlaceService placeService, IMapper mapper)
        {
            _mapper = mapper;
            _placeService = placeService;
        }

        [HttpGet("get")]
        public async Task<List<PlaceDTO>> Get()
        {
            return  await _placeService.Get();
        }


        [HttpGet("sort")]
        public async Task<List<PlaceDTO>> Sort()
        {
            return await _placeService.SortDescending();
        }



    }
}
