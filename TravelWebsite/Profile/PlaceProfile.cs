﻿using AutoMapper;
using DataAccess.Entities;
using DataAccess.DTO;
public class PlaceProfile : Profile
{
    public PlaceProfile()
    {
        CreateMap<Place, PlaceDTO>();
        CreateMap<PlaceDTO, Place>();
    }
}