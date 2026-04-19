using MAUI.ViewModels;     
using Services;
using Storage;
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

            // Реєструємо доступ до файлу
            builder.Services.AddSingleton<FileStorageProvider>();
            // Реєструємо Репозиторій
            builder.Services.AddSingleton<IExpenseRepository, ExpenseRepository>();

            // Реєструємо Репозиторій 
            builder.Services.AddSingleton<IExpenseRepository, ExpenseRepository>();

            // Реєструємо Сервіс 
            builder.Services.AddSingleton<IExpenseService, ExpenseService>();

            // Реєструємо ViewModels 
            builder.Services.AddTransient<MainViewModel>();

            // Реєструємо Головну сторінку
            builder.Services.AddTransient<MainPage>();

            return builder.Build();
        }
    }
}