namespace TravelWebsite.Business.Models.DTO
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string ShortDescription { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Distance { get; set; } = "";
        public decimal Price { get; set; } = default!;
        public int NumberOfRooms { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfKids { get; set; }
        public string Type { get; set; } = default!;
        public string City { get; set; } = default!;
        public IEnumerable<BookingDTO> Bookings { get; set; } = default!;
        public IEnumerable<PropertyImageDTO> Images { get; set; } = default!;
    }
}
