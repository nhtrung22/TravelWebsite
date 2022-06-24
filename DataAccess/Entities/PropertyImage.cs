using TravelWebsite.DataAccess.Common;

namespace TravelWebsite.DataAccess.Entities
{
    public class PropertyImage : AuditableEntity
    {
        public int Id { get; set; }
        public byte[] File { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public int PropertyId { get; set; }
        public Property Property { get; set; } = default!;
    }
}