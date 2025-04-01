namespace SalesApp.Models
{
    public class SaleViewModel
    {      
        public string? Segment { get; set; }
        public string? Country { get; set; }
        public string? Product { get; set; }
        public string? DiscountBand { get; set; }
        public decimal UnitsSold { get; set; }
        public string? ManufacturingPrice { get; set; }
        public string? SalePrice { get; set; }
        public DateTime Date { get; set; }
    }
}
