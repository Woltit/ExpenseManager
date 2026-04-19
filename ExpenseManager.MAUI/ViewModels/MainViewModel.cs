using ExpenseManager.MAUI;
using Models.DTOs;
using Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MAUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IExpenseService _expenseService;

        public ObservableCollection<WalletListDto> Wallets { get; set; }

        public ICommand WalletSelectedCommand { get; }

        public MainViewModel(IExpenseService expenseService)
        {
            _expenseService = expenseService;


            WalletSelectedCommand = new Command<WalletListDto>(async (selectedWallet) =>
            {
                if (selectedWallet == null) return;

                var walletDetails = await _expenseService.GetWalletDetailsAsync(selectedWallet.Id);

                var detailsViewModel =  new WalletDetailsViewModel(walletDetails, _expenseService);

                await Application.Current.Windows[0].Page.Navigation.PushAsync(new WalletDetailsPage(detailsViewModel));
            });
        }
        public async Task LoadDataAsync()
        {
            var wallets = await _expenseService.GetAllWalletsAsync();
            Wallets = new ObservableCollection<WalletListDto>(wallets);
            OnPropertyChanged(nameof(Wallets)); 
        }
    }
}