using ExpenseManager.MAUI;
using Models.DTOs;
using Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Storage; 

namespace MAUI.ViewModels
{
    public class WalletDetailsViewModel : BaseViewModel
    {
        private readonly IExpenseService _expenseService;

        private WalletDetailDto _wallet;
        public WalletDetailDto Wallet
        {
            get => _wallet;
            set { _wallet = value; OnPropertyChanged(); }
        }

        public ObservableCollection<TransactionListDto> Transactions { get; set; }

        public ICommand TransactionSelectedCommand { get; private set; }
        public ICommand AddTransactionCommand { get; private set; }
        public ICommand EditTransactionCommand { get; private set; }
        public ICommand DeleteTransactionCommand { get; private set; }

        public WalletDetailsViewModel(WalletDetailDto wallet, IExpenseService expenseService)
        {
            Wallet = wallet;
            _expenseService = expenseService;
            Transactions = new ObservableCollection<TransactionListDto>(wallet.Transactions);

            // Перехід на деталі транзакції
            TransactionSelectedCommand = new Command<TransactionListDto>(async (selectedTx) =>
            {
                if (selectedTx == null) return;
                var txDetails = await _expenseService.GetTransactionDetailsAsync(selectedTx.Id);
                var txViewModel = new TransactionDetailsViewModel(txDetails);
                await Application.Current.Windows[0].Page.Navigation.PushAsync(new TransactionDetailsPage(txViewModel));
            });

            // Додати транзакцію
            AddTransactionCommand = new Command(async () =>
            {
                var page = Application.Current.Windows[0].Page;

                string amountStr = await page.DisplayPromptAsync("Сума", "Введіть суму (з мінусом для витрат):", keyboard: Keyboard.Numeric);
                if (!decimal.TryParse(amountStr, out decimal amount)) return;

                string catStr = await page.DisplayActionSheet("Категорія", "Відміна", null, "Food", "Transport", "Entertainment", "Salary", "Other");
                if (catStr == "Відміна" || catStr == null) return;
                Enum.TryParse(catStr, out ExpenseCategory category);

                string desc = await page.DisplayPromptAsync("Опис", "Введіть опис транзакції:");

                await _expenseService.AddTransactionAsync(Wallet.Id, amount, category, desc);
                await LoadDataAsync();
            });

            // Видалити транзакцію
            DeleteTransactionCommand = new Command<TransactionListDto>(async (tx) =>
            {
                if (tx == null) return;
                var page = Application.Current.Windows[0].Page;

                bool confirm = await page.DisplayAlert("Видалення", "Дійсно видалити цю транзакцію?", "Так", "Ні");
                if (confirm)
                {
                    await _expenseService.DeleteTransactionAsync(tx.Id);
                    await LoadDataAsync();
                }
            });
        }

        // Метод для оновлення списку та балансу гаманця після змін
        public async Task LoadDataAsync()
        {
            var updatedWallet = await _expenseService.GetWalletDetailsAsync(Wallet.Id);
            if (updatedWallet != null)
            {
                Wallet = updatedWallet;
                Transactions.Clear();
                foreach (var tx in updatedWallet.Transactions)
                {
                    Transactions.Add(tx);
                }
            }
        }
    }
}