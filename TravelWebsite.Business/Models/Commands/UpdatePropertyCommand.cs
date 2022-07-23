namespace TravelWebsite.Business.Models.Commands
{
    public class UpdatePropertyCommand
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Address { get; set; } = "";

        public string Distance { get; set; } = "";

        public string Description { get; set; } = "";

        public string ShortDescription { get; set; } = "";

        public decimal Price { get; set; }

        public int NumberOfAdults { get; set; }

        public int NumberOfKids { get; set; }

        public int NumberOfRooms { get; set; }

        public string Type { get; set; } = "";

        public string City { get; set; } = "";

        public IEnumerable<PropertyImage> Images { get; set; } = Enumerable.Empty<PropertyImage>();
    }
}
