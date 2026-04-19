using ExpenseManager.MAUI.ViewModels;
using MAUI.ViewModels;
using Microsoft.Maui.Controls;

namespace ExpenseManager.MAUI
{
    public partial class TransactionDetailsPage : ContentPage
    {
        public TransactionDetailsPage(TransactionDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}