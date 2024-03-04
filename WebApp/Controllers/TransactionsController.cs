using Microsoft.AspNetCore.Mvc;
using UseCases.TransactionsUseCases;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using CoreBusiness;
using WebApp.ViewModels;
using UseCases;

namespace WebApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ISearchTransactionsUseCase searchTransactionsUseCase;

        public TransactionsController(ISearchTransactionsUseCase searchTransactionsUseCase)
        {
            this.searchTransactionsUseCase = searchTransactionsUseCase;
        }

        public IActionResult Index()
        {
            TransactionsViewModel transactionsViewModel = new TransactionsViewModel();
            return View("TransactionsIndex", transactionsViewModel);
        }

        [HttpPost]
        public IActionResult Search(TransactionsViewModel transactionsViewModel)
        {
            var matchingTransactions = searchTransactionsUseCase.Execute(
                transactionsViewModel.CashierName ?? string.Empty, 
                transactionsViewModel.StartDate, 
                transactionsViewModel.EndDate);

            transactionsViewModel.Transactions = matchingTransactions;

            return View("TransactionsIndex", transactionsViewModel);
        }
    }
}
