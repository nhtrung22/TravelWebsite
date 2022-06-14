using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Models.DTO
{
    public class PlaceDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ShortDicription { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longtitude { get; set; }

        public PlaceType PlaceType { get; set; }

        public City City { get; set; }

    }
}
