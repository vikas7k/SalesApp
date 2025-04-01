using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Models;
using SalesService;

namespace SalesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISalesFileProcessor _salesFileProcessor;
        private const string CsvFile = "CSV/Data.csv";
        public HomeController(ISalesFileProcessor salesFileProcessor,ILogger<HomeController> logger)
        {
            _salesFileProcessor = salesFileProcessor;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var salesDataViewModel = new SalesDataViewModel();
            try
            {                
                var salesRecordList = _salesFileProcessor.GetSalesRecordList(CsvFile);

                if (salesRecordList.SaleRecords != null && salesRecordList.SaleRecords.Any())
                {
                    salesDataViewModel.SaleViewModels = new List<SaleViewModel>(salesRecordList.SaleRecords.Select(s => new SaleViewModel
                    {
                        Segment = s.Segment,
                        Country = s.Country,
                        Product = s.Product,
                        DiscountBand = s.DiscountBand,
                        UnitsSold = s.UnitsSold,
                        ManufacturingPrice = s.ManufacturingPrice,
                        SalePrice = s.SalePrice,
                        Date = s.Date
                    }).OrderBy(s => s.Segment).ThenBy(s=> s.Country).ToList());
                }

                if (salesRecordList.ErrorRecords != null && salesRecordList.ErrorRecords.Any())
                {
                    salesDataViewModel.ErrorViewModels = new List<ErrorViewModel>(salesRecordList.ErrorRecords.Select(s => new ErrorViewModel
                    {
                        Segment = s.Segment,
                        Country = s.Country,
                        Product = s.Product,
                        DiscountBand = s.DiscountBand,
                        UnitsSold = s.UnitsSold,
                        ManufacturingPrice = s.ManufacturingPrice,
                        SalePrice = s.SalePrice,
                        Date = s.Date,
                        Message = s.Message
                    }).OrderBy(s => s.Segment).ThenBy(s => s.Country).ToList());
                }               
            }
            catch (Exception ex)
            {
                salesDataViewModel.Error = ex.Message;
                _logger.LogError(ex.Message);
            }
            return View(salesDataViewModel);
        }
       
    }
}
