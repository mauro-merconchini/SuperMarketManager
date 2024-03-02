namespace WebApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public int QuantityBefore { get; set; }
        public int QuantitySold { get; set; }
        public double Price { get; set; }
        public string CashierName { get; set; }
    }
}
