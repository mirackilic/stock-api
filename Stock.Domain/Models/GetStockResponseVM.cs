namespace Stock.Domain.Models
{
    public class GetStockByVariantCodeResponseVM : GetStockBaseResponseVM
    {
        public string VariantCode { get; set; }
    }

    public class GetStockByProductCodeResponseVM : GetStockBaseResponseVM
    {
        public char ProductCode { get; set; }
    }

    public class GetStockBaseResponseVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}