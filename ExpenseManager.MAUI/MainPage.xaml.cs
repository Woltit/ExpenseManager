using Microsoft.Maui.Controls;
using ExpenseManager.MAUI.ViewModels;

namespace ExpenseManager.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel; 
        }
    }
}