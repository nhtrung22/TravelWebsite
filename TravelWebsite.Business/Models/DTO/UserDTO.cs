﻿using TravelWebsite.DataAccess.Entities;
using TravelWebsite.DataAccess.Enums;

namespace TravelWebsite.Business.Models.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}