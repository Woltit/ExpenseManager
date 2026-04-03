using Microsoft.Maui.Controls;
using Models;

namespace ExpenseManager.MAUI
{
    public partial class TransactionDetailsPage : ContentPage
    {
        public TransactionDetailsPage(TransactionModel transaction)
        {
            InitializeComponent();

            // Прив'язуємо дані обраної транзакції до інтерфейсу
            BindingContext = transaction;
        }
    }
}