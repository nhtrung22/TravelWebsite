using System.ComponentModel.DataAnnotations;
using TravelWebsite.DataAccess.Common;

namespace TravelWebsite.DataAccess.Entities
{
    public class City : AuditableEntity
    {
        [Key]
        public int Id { get; set; } // PK
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Link { get; set; } = default!;
        public ICollection<Property> Properties { get; set; } = default!;

    }
}
