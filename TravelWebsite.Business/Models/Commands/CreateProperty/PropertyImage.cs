namespace TravelWebsite.Business.Models.Commands.CreatePlace
{
    public class PropertyImage
    {
        public byte[] File { get; set; } = default!;
        public string FileName { get; set; } = default!;
    }
}
