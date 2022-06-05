﻿namespace TravelWebsite.Business.Services;

using TravelWebsite.Business.DTO;
using TravelWebsite.Business.JwtModel;
using TravelWebsite.DataAccess.Entities.JwtModel;

public interface IUserService
{
    Task<IEnumerable<UserDTO>> GetAll();
    Task<UserDTO> GetById(Guid id);
}