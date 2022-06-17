using TravelWebsite.DataAccess.Common;

namespace TravelWebsite.DataAccess.Entities
{
    public class PlaceImage : AuditableEntity
    {
        public int Id { get; set; }
        public byte[] File { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public int PlaceId { get; set; }
        public Place Place { get; set; } = default!;
    }
}