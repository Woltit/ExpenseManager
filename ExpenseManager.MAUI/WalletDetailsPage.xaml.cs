using ExpenseManager.MAUI.ViewModels;
using MAUI.ViewModels;
using Microsoft.Maui.Controls;

namespace ExpenseManager.MAUI
{
    public partial class WalletDetailsPage : ContentPage
    {
        public WalletDetailsPage(WalletDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}