﻿using System.ComponentModel.DataAnnotations;
using TravelWebsite.DataAccess.Common;

namespace TravelWebsite.DataAccess.Entities
{
    public class Place : AuditableEntity
    {
        [Key]
        public int Id { get; set; } // PK
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Discription { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public int NumberOfAdults { get; set; }
        public int NumberOfKids { get; set; }
        public int CityId { get; set; } = default!;
        public City City { get; set; } = default!;
        public int PlaceTypeId { get; set; } = default!;
        public PlaceType PlaceType { get; set; } = default!;
        public Guid UserId { get; set; } = default!;
        public User User { get; set; } = default!;
        public ICollection<Booking> Bookings { get; set; } = default!;
        public ICollection<PlaceImage> Images { get; set; } = default!;
    }
}
