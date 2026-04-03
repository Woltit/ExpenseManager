using Microsoft.Maui.Controls;
using Services;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseManager.MAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly IExpenseService _expenseService;

        // MAUI сам створює сервіс і передає його сюди через конструктор.
        public MainPage(IExpenseService expenseService)
        {
            InitializeComponent();
            _expenseService = expenseService;

            LoadData();
        }

        private void LoadData()
        {
            // Отримуємо гаманці через наш сервіс
            List<WalletModel> wallets = _expenseService.GetAllWallets();

            // Передаємо дані у наш графічний список (WalletsCollection)
            WalletsCollection.ItemsSource = wallets;
        }

        // Цей метод викликається, коли користувач клікає на гаманець
        private async void OnWalletSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is WalletModel selectedWallet)
            {
                ((CollectionView)sender).SelectedItem = null;

                // Переходимо на нову сторінку, передаємо їй обраний гаманець
                await Navigation.PushAsync(new WalletDetailsPage(selectedWallet));
            }
        }
    }
}