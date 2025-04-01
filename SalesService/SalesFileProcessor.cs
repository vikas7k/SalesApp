using System.Text;

namespace SalesService
{
    public class SalesFileProcessor : ISalesFileProcessor
    {      
        public SalesData GetSalesRecordList (string scvFile)
        {
            List<SaleRecord> SalesRecords = new List<SaleRecord>();
            List<ErrorRecord> ErrorRecords = new List<ErrorRecord>();

            var fileRecords   = File.ReadAllLines(scvFile, Encoding.GetEncoding("ISO-8859-1")).Skip(1);

            if (fileRecords.Any())
            {
                foreach (var record in fileRecords)
                {
                    try
                    {
                        SalesRecords.Add(SaleRecord.FromCsv(record));
                    }
                    catch(Exception ex){
                        ErrorRecords.Add(ErrorRecord.FromCsv(record, ex.Message));
                    }
                }
            }

            return new SalesData
            {
                SaleRecords = SalesRecords,
                ErrorRecords= ErrorRecords
            };

        }
    }
}
