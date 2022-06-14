using TravelWebsite.DataAccess.Entities;

namespace TravelWebsite.DataAccess.Models.DTO
{
    public class CityDTO
    {

        public string CityName { get; set; }

        public string Description { get; set; }


        // City - Place
        public ICollection<Place> Places { get; set; }

    }
}
