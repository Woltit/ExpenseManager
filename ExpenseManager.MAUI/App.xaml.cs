using Microsoft.Maui.Controls;

namespace ExpenseManager.MAUI
{
    public partial class App : Application
    {
        public App(MainPage mainPage)
        {
            InitializeComponent();

            // Загортаємо нашу сторінку в NavigationPage, щоб мати можливість навігувати між сторінками 
            MainPage = new NavigationPage(mainPage);
        }
    }
}