namespace Tattoo.Entities
{
    public class Pricing
    {
        public long Id { get; set; }
        public float Price { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Tattooer Tattooer { get; set; }
        public long TattooerId { get; set; }
        public TattooStyle TattooStyle { get; set; }
        public long TattooStyleId { get; set;}
        public TattooType TattooType { get; set; }
        public long TattooTypeId { get; set; }
    }
}
