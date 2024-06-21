namespace Tattoo.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string? Deposit { get; set; }
        public Pricing? Pricing { get; set; }
        public long PricingId { get; set; }
        public User? Customer { get; set; }
        public string? CustomerId { get; set; }
        public Tattoo? Tattoo { get; set; }
        public long TattooId { get; set; }
    }
}
