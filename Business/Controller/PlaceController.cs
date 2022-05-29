﻿using AutoMapper;
using Business.Services;
using DataAccess.DTO;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<List<PlaceDTO>> Get()
        {
            return  await _placeService.GetAllAsysnc();
        }


        [HttpGet("sort")]
        public async Task<List<PlaceDTO>> Sort()
        {
            return await _placeService.SortDescending();
        }



    }
}
