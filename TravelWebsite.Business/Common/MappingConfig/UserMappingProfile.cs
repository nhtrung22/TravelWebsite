﻿using AutoMapper;
using TravelWebsite.Business.DTO;
using TravelWebsite.DataAccess.Entities;

namespace Business.Common.MappingConfig
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}