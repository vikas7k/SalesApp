
namespace SalesService
{
    public class ErrorRecord
    {
        public string? Segment { get; set; }
        public string? Country { get; set; }
        public string? Product { get; set; }
        public string? DiscountBand { get; set; }
        public string? UnitsSold { get; set; }
        public string? ManufacturingPrice { get; set; }
        public string? SalePrice { get; set; }
        public string? Date { get; set; }
        public string? Message { get; set; }

        public static ErrorRecord FromCsv(string csvLine, string message)
        {
            string[] values = csvLine.Split(',');
            ErrorRecord errorRecord = new ErrorRecord();
            errorRecord.Segment = values[0];
            errorRecord.Country = values[1];
            errorRecord.Product = values[2];
            errorRecord.DiscountBand = values[3];
            errorRecord.UnitsSold = values[4];
            errorRecord.ManufacturingPrice = values[5];
            errorRecord.SalePrice = values[6];
            errorRecord.Date = values[7];
            errorRecord.Message = message;
            return errorRecord;
        }
    }
}
