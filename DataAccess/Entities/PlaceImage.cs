using TravelWebsite.DataAccess.Common;

namespace TravelWebsite.DataAccess.Entities
{
    public class PlaceImage : AuditableEntity
    {
        public int Id { get; set; }
        public Byte[] File { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public Place Place { get; set; } = default!;
    }
}