
using System.Text.Json;


namespace Storage
{
    public class FileStorageProvider
    {
        private readonly string _filePath;

        public FileStorageProvider()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _filePath = Path.Combine(appDataPath, "expense_database.json");
        }

        public async Task<DatabaseModel> LoadDatabaseAsync()
        {
            if (!File.Exists(_filePath))
            {
                var initialDb = CreateInitialData();
                await SaveDatabaseAsync(initialDb);
                return initialDb;
            }

            using var stream = File.OpenRead(_filePath);
            return await JsonSerializer.DeserializeAsync<DatabaseModel>(stream);
        }

        public async Task SaveDatabaseAsync(DatabaseModel db)
        {
            using var stream = File.Create(_filePath);
            await JsonSerializer.SerializeAsync(stream, db, new JsonSerializerOptions { WriteIndented = true });
        }

        private DatabaseModel CreateInitialData()
        {
            var db = new DatabaseModel();

            Guid monoCardID = Guid.NewGuid();
            Guid privatBankCardID = Guid.NewGuid();
            Guid visaCardID = Guid.NewGuid();

            db.Wallets.Add(new WalletStorageModel(monoCardID, "MonoCard", Currency.UAH));
            db.Wallets.Add(new WalletStorageModel(privatBankCardID, "PrivatBankCard", Currency.UAH));
            db.Wallets.Add(new WalletStorageModel(visaCardID, "VisaCard", Currency.USD));

            db.Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, 50000m, ExpenseCategory.Other, "Salary", DateTime.Now.AddDays(-10)));
            db.Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -500.50m, ExpenseCategory.Food, "Dinner", DateTime.Now.AddDays(-9)));
            db.Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -1500m, ExpenseCategory.Transport, "Train tickets", DateTime.Now.AddDays(-9)));
            db.Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -2000m, ExpenseCategory.Entertainment, "Amusement park", DateTime.Now.AddDays(-7)));
            db.Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -3000m, ExpenseCategory.Utilities, "-", DateTime.Now.AddDays(-5)));
            db.Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -2500m, ExpenseCategory.Healthcare, "Doctor appointment", DateTime.Now.AddDays(-4)));
            db.Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -1000m, ExpenseCategory.Education, "Programming book", DateTime.Now.AddDays(-3)));
            db.Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -4000m, ExpenseCategory.Shopping, "Zara", DateTime.Now.AddDays(-2)));
            db.Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -3500m, ExpenseCategory.Travel, "Travel agency", DateTime.Now.AddDays(-2)));
            db.Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -4500m, ExpenseCategory.Food, "Silpo", DateTime.Now.AddDays(-1)));


            db.Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), visaCardID, 1000m, ExpenseCategory.Other, "Salary", DateTime.Now.AddDays(-8)));
            db.Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), visaCardID, -20m, ExpenseCategory.Food, "Coffe and dessert", DateTime.Now.AddDays(-7)));

            return db;
        }
    }
}