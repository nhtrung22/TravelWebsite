using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Models.DTO
{
    public class PlaceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ShortDicription { get; set; } = default!;
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
        public PlaceType PlaceType { get; set; } = default!;
        public City City { get; set; } = default!;
        public IEnumerable<PlaceImageDTO> PlaceImages { get; set; } = default!;
    }
}
