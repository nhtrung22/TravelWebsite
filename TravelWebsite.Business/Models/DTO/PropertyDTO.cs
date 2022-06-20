using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Models.DTO
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ShortDicription { get; set; } = default!;
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
        public PropertyTypeDTO Type { get; set; } = default!;
        public CityDTO City { get; set; } = default!;
        public IEnumerable<PropertyImageDTO> Images { get; set; } = default!;
    }
}
