
namespace SalesApp.Models
{
    public class SalesDataViewModel
    {
        public List<SaleViewModel>? SaleViewModels { get; set; }
        public List<ErrorViewModel>? ErrorViewModels { get; set; }      
        public string Error { get; set; } = string.Empty;
    }
}
