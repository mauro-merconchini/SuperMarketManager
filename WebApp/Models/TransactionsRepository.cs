namespace WebApp.Models
{
    public static class TransactionsRepository
    {

        private static List<Transaction> transactions = new List<Transaction>();

        public static IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(t => t.DateTime.Date == date.Date);
            else
                return transactions.Where(t =>
                    t.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                    t.DateTime.Date == date.Date);
        }

        public static IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(t => t.DateTime >= startDate.Date && t.DateTime <= endDate.Date.AddDays(1).Date);
            else
                return transactions.Where(t =>
                    t.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                    t.DateTime >= startDate.Date && t.DateTime <= endDate.Date.AddDays(1).Date);
        }

        public static void Add(string cashierName, int productId, string productName, double price, int qtyBefore, int qtyAfter)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                DateTime = DateTime.Now,
                Price = price,
                QuantityBefore = qtyBefore,
                QuantityAfter = qtyAfter,
                CashierName = cashierName
            };

            if (transactions != null && transactions.Count > 0)
            {
                var maxId = transactions.Max(x => x.Id);
                transaction.Id = maxId + 1;
            }
            else
            {
                transaction.Id = 1;
            }

            transactions?.Add(transaction);
        }

    }
}
