namespace TravelWebsite.Business.Models.DTO
{
    public class PropertyByCityDTO
    {
        public int Number { get; set; }
        public CityDTO City { get; set; } = default!;
    }
}
