﻿namespace TravelWebsite.Business.Models.DTO
{
    public class PropertyByTypeDTO
    {
        public int Number { get; set; }
        public PropertyTypeDTO Type { get; set; } = default!;
    }
}
