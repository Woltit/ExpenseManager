using MAUI.ViewModels;


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