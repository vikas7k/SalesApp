
namespace SalesService
{
    public class SaleRecord
    {
        public string? Segment { get; set; }
        public string? Country { get; set; }
        public string? Product { get; set; }
        public string? DiscountBand { get; set; }
        public decimal UnitsSold { get; set; }
        public string? ManufacturingPrice { get; set; }
        public string? SalePrice { get; set; }
        public DateTime Date { get; set; }

        public static SaleRecord FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            SaleRecord saleRecord = new SaleRecord();
            saleRecord.Segment = values[0];
            saleRecord.Country = values[1];
            saleRecord.Product = values[2];
            saleRecord.DiscountBand = values[3];
            saleRecord.UnitsSold = Convert.ToDecimal(values[4]);
            saleRecord.ManufacturingPrice = values[5];
            saleRecord.SalePrice = values[6];
            saleRecord.Date = DateTime.ParseExact(values[7], "dd/MM/yyyy", null); 
            return saleRecord;
        }
    }
}
