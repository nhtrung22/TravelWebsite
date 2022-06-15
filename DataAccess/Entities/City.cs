using System.ComponentModel.DataAnnotations;

namespace TravelWebsite.DataAccess.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; } // PK

        public string Name { get; set; }

        public string Description { get; set; }


        // City - Place
        public ICollection<Place> Places { get; set; }

    }
}
