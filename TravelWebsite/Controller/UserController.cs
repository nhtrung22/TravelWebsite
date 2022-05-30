﻿using AutoMapper;
using Business.Common.Interfaces;
using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebsite.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<UserDTO>> Get()
        {
            //validation
            return  await _userService.GetAllAsysnc();
        }

        [HttpPost]
        public async Task<UserDTO> Add(UserDTO user)
        {
            return await _userService.Add(user);
        }

        [HttpDelete]
        public async Task Remove(string email)
        {
            await _userService.Remove(email);
        }
            
        [HttpPut]
        public async Task Update(UserDTO user)
        {
            await _userService.Update(user);
        }

        //[HttpPut]
        //public async Task Login(string userName, string password)
        //{
        //    //await _userService.Add(user);
        //}


    }
}