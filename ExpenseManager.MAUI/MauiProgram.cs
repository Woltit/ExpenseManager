using ExpenseManager.MAUI.ViewModels;     
using Services;
using Storage.Repositories; 

namespace ExpenseManager.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // 1. Реєструємо Репозиторій 
            builder.Services.AddSingleton<IExpenseRepository, ExpenseRepository>();

            // 2. Реєструємо Сервіс 
            builder.Services.AddSingleton<IExpenseService, ExpenseService>();

            // 3. Реєструємо ViewModels 
            builder.Services.AddTransient<MainViewModel>();

            // 4. Реєструємо Головну сторінку
            builder.Services.AddTransient<MainPage>();

            return builder.Build();
        }
    }
}