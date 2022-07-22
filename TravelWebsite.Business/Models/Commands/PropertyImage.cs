namespace TravelWebsite.Business.Models.Commands
{
    public class PropertyImage
    {
        public byte[] File { get; set; } = default!;
        public string FileName { get; set; } = default!;
    }
}
