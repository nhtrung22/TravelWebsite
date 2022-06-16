namespace TravelWebsite.Business.Models.Commands
{
    public class UpdatePlaceCommand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ShortDicription { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longtitude { get; set; }

        public int PlaceTypeId { get; set; }

        public int CityId { get; set; }
    }
}
