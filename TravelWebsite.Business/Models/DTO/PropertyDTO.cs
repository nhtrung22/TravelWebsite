namespace TravelWebsite.Business.Models.DTO
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string ShortDescription { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public int NumberOfRooms { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfKids { get; set; }
        public PropertyTypeDTO Type { get; set; } = default!;
        public CityDTO City { get; set; } = default!;
        public IEnumerable<PropertyImageDTO> Images { get; set; } = default!;
    }
}
