namespace TravelWebsite.Business.Models.Commands.CreatePlace
{
    public class PlaceImage
    {
        public byte[] File { get; set; } = default!;
        public string FileName { get; set; } = default!;
    }
}
