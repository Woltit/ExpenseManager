using Models.DTOs;
using Services;
using MAUI.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ExpenseManager.MAUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IExpenseService _expenseService;

        public ObservableCollection<WalletListDto> Wallets { get; set; }

        public ICommand WalletSelectedCommand { get; }

        public MainViewModel(IExpenseService expenseService)
        {
            _expenseService = expenseService;

            Wallets = new ObservableCollection<WalletListDto>(_expenseService.GetAllWallets());

            WalletSelectedCommand = new Command<WalletListDto>(async (selectedWallet) =>
            {
                if (selectedWallet == null) return;

                var walletDetails = _expenseService.GetWalletDetails(selectedWallet.Id);

                var detailsViewModel = new WalletDetailsViewModel(walletDetails, _expenseService);

                await Application.Current.MainPage.Navigation.PushAsync(new WalletDetailsPage(detailsViewModel));
            });
        }
    }
}