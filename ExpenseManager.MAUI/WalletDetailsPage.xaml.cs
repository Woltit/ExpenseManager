using Microsoft.Maui.Controls;
using Models;
using System.Linq;

namespace ExpenseManager.MAUI
{
    public partial class WalletDetailsPage : ContentPage
    {
        // Конструктор приймає конкретний гаманець (на який клікнули)
        public WalletDetailsPage(WalletModel wallet)
        {
            InitializeComponent();

            BindingContext = wallet;
        }

        private async void OnTransactionSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is TransactionModel selectedTransaction)
            {
                ((CollectionView)sender).SelectedItem = null;

                // Переходимо на третю сторінку, передаємо їй обрану транзакцію
                await Navigation.PushAsync(new TransactionDetailsPage(selectedTransaction));
            }
        }
    }
}