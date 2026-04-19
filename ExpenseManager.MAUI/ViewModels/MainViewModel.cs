using ExpenseManager.MAUI;
using Models.DTOs;
using Services;
using System.Collections.ObjectModel;
using Storage;
using System.Windows.Input;

namespace MAUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IExpenseService _expenseService;

        public ObservableCollection<WalletListDto> Wallets { get; set; }

        public ICommand WalletSelectedCommand { get; private set; }
        public ICommand AddWalletCommand { get; private set; }
        public ICommand EditWalletCommand { get; private set; }
        public ICommand DeleteWalletCommand { get; private set; }

        public MainViewModel(IExpenseService expenseService)
        {
            _expenseService = expenseService;

            // Команда вибору гаманця 
            WalletSelectedCommand = new Command<WalletListDto>(async (selectedWallet) =>
            {
                if (selectedWallet == null) return;

                var walletDetails = await _expenseService.GetWalletDetailsAsync(selectedWallet.Id);
                var detailsViewModel = new WalletDetailsViewModel(walletDetails, _expenseService);

                await Application.Current.Windows[0].Page.Navigation.PushAsync(new WalletDetailsPage(detailsViewModel));
            }); 

            // Команда додавання гаманця
            AddWalletCommand = new Command(async () =>
            {
                var page = Application.Current.Windows[0].Page;

                string name = await page.DisplayPromptAsync("Новий гаманець", "Введіть назву гаманця:");
                if (string.IsNullOrWhiteSpace(name)) return;

                string currStr = await page.DisplayActionSheet("Оберіть валюту", "Відміна", null, "UAH", "USD", "EUR");
                if (currStr == "Відміна" || currStr == null) return;

                Currency currency = currStr == "USD" ? Currency.USD : (currStr == "EUR" ? Currency.EUR : Currency.UAH);

                await _expenseService.AddWalletAsync(name, currency);
                await LoadDataAsync();
            });

            // Команда редагування гаманця
            EditWalletCommand = new Command<WalletListDto>(async (wallet) =>
            {
                if (wallet == null) return;
                var page = Application.Current.Windows[0].Page;

                string newName = await page.DisplayPromptAsync("Редагування", "Введіть нову назву:", initialValue: wallet.Name);
                if (string.IsNullOrWhiteSpace(newName) || newName == wallet.Name) return;

                await _expenseService.UpdateWalletAsync(wallet.Id, newName, wallet.Currency);
                await LoadDataAsync();
            });

            // Команда видалення гаманця
            DeleteWalletCommand = new Command<WalletListDto>(async (wallet) =>
            {
                if (wallet == null) return;
                var page = Application.Current.Windows[0].Page;

                bool confirm = await page.DisplayAlert("Підтвердження", $"Ви дійсно хочете видалити '{wallet.Name}'? Всі транзакції також будуть видалені!", "Видалити", "Відміна");
                if (confirm)
                {
                    await _expenseService.DeleteWalletAsync(wallet.Id);
                    await LoadDataAsync();
                }
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