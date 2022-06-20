namespace TravelWebsite.Business.Models.Commands.CreatePlace
{
    public class CreatePropertyCommand
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; } = default!;
        public int NumberOfAdults { get; set; }
        public int NumberOfKids { get; set; }
        public int PlaceTypeId { get; set; }
        public int CityId { get; set; }
        public IEnumerable<PropertyImage> Images { get; set; } = Enumerable.Empty<PropertyImage>();
    }
}
