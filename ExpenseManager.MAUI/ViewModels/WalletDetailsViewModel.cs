using Models.DTOs;
using Services;
using System.Collections.ObjectModel;
using ExpenseManager.MAUI;
using System.Windows.Input;

namespace MAUI.ViewModels
{
    public class WalletDetailsViewModel : BaseViewModel
    {
        private readonly IExpenseService _expenseService;

        public WalletDetailDto Wallet { get; set; }
        public ObservableCollection<TransactionListDto> Transactions { get; set; }
        public ICommand TransactionSelectedCommand { get; }

        public WalletDetailsViewModel(WalletDetailDto wallet, IExpenseService expenseService)
        {
            Wallet = wallet;
            _expenseService = expenseService;
            Transactions = new ObservableCollection<TransactionListDto>(wallet.Transactions);

            TransactionSelectedCommand = new Command<TransactionListDto>(async (selectedTx) =>
            {
                if (selectedTx == null) return;

                var txDetails = await _expenseService.GetTransactionDetailsAsync(selectedTx.Id);

                var txViewModel = new TransactionDetailsViewModel(txDetails);
                await Application.Current.MainPage.Navigation.PushAsync(new TransactionDetailsPage(txViewModel));
            });
        }
    }
}