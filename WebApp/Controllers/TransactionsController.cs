using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
            return View("TransactionsIndex", transactionsViewModel);
        }

        [HttpPost]
        public IActionResult Search(TransactionsViewModel transactionsViewModel)
        {
            var matchingTransactions = TransactionsRepository.Search(
                transactionsViewModel.CashierName ?? string.Empty, 
                transactionsViewModel.StartDate, 
                transactionsViewModel.EndDate);

            transactionsViewModel.Transactions = matchingTransactions;

            return View("TransactionsIndex", transactionsViewModel);
        }
    }
}
