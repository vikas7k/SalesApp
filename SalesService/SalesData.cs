using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesService
{
    public class SalesData
    {
        public List<SaleRecord>? SaleRecords { get; set; }
        public List<ErrorRecord>? ErrorRecords { get; set; }

    }
}
