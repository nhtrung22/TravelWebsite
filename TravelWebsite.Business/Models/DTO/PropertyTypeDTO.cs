using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.Models.DTO
{
    public class PropertyTypeDTO
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Link { get; set; } = default!;
    }
}
