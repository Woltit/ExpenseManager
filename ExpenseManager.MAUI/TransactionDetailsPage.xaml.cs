using MAUI.ViewModels;


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