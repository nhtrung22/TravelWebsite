namespace TravelWebsite.Business.Models.Commands.CreatePlace
{
    public class CreatePropertyCommand
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string Description { get; set; } = "";
        public string Distance { get; set; } = "";
        public decimal Price { get; set; } = default!;
        public int NumberOfAdults { get; set; }
        public int NumberOfKids { get; set; }
        public int TypeId { get; set; } = 1;
        public int CityId { get; set; } = 1;
        public IEnumerable<PropertyImage> Images { get; set; } = Enumerable.Empty<PropertyImage>();
    }
}
