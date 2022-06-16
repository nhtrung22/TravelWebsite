namespace TravelWebsite.Business.Models.Commands
{
    public class CreatePlaceCommand
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string ShortDicription { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longtitude { get; set; }

        public int PlaceTypeID { get; set; }

        public int CityId { get; set; }
    }
}
