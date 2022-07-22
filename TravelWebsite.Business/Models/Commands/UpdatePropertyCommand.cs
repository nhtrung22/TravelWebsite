namespace TravelWebsite.Business.Models.Commands
{
    public class UpdatePropertyCommand
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Address { get; set; } = "";

        public string Description { get; set; } = "";

        public string ShortDescription { get; set; } = "";

        public decimal Latitude { get; set; }

        public decimal Longtitude { get; set; }

        public int PlaceTypeId { get; set; } = 1;

        public int CityId { get; set; } = 1;

        public IEnumerable<PropertyImage> Images { get; set; } = Enumerable.Empty<PropertyImage>();
    }
}
