using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.Business.DTO
{
    public class PlaceTypeDTO
    {

        public string Name { get; set; }

        public string Description { get; set; }

        // PlaceType - Place
        public ICollection<Place> Places { get; set; }

    }
}
