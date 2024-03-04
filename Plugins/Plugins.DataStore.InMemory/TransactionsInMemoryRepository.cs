using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionsInMemoryRepository : ITransactionRepository
    {
        private  List<Transaction> transactions = new List<Transaction>();

        public  IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(t => t.DateTime.Date == date.Date);
            else
                return transactions.Where(t =>
                    t.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                    t.DateTime.Date == date.Date);
        }

        public  IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(t => t.DateTime >= startDate.Date && t.DateTime <= endDate.Date.AddDays(1).Date);
            else
                return transactions.Where(t =>
                    t.CashierName.ToLower().Contains(cashierName.ToLower()) &&
                    t.DateTime >= startDate.Date && t.DateTime <= endDate.Date.AddDays(1).Date);
        }

        public  void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
        {
            var transaction = new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                DateTime = DateTime.Now,
                Price = price,
                QuantityBefore = beforeQty,
                QuantitySold = soldQty,
                CashierName = cashierName
            };

            if (transactions != null && transactions.Count > 0)
            {
                var maxId = transactions.Max(t => t.Id);
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
