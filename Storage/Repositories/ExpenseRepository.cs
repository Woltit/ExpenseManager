namespace Storage.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly FileStorageProvider _storage;

        public ExpenseRepository(FileStorageProvider storage)
        {
            _storage = storage;
        }

        public async Task<List<WalletStorageModel>> GetAllWalletsAsync()
        {
            var db = await _storage.LoadDatabaseAsync();
            return db.Wallets.ToList();
        }

        public async Task<WalletStorageModel> GetWalletByIdAsync(Guid id)
        {
            var db = await _storage.LoadDatabaseAsync();
            return db.Wallets.FirstOrDefault(w => w.Id == id);
        }

        public async Task AddWalletAsync(WalletStorageModel wallet)
        {
            var db = await _storage.LoadDatabaseAsync();
            db.Wallets.Add(wallet);
            await _storage.SaveDatabaseAsync(db);
        }

        public async Task UpdateWalletAsync(WalletStorageModel wallet)
        {
            var db = await _storage.LoadDatabaseAsync();
            var existing = db.Wallets.FirstOrDefault(w => w.Id == wallet.Id);
            if (existing != null)
            {
                existing.Name = wallet.Name;
                existing.Currency = wallet.Currency;
                await _storage.SaveDatabaseAsync(db);
            }
        }

        public async Task DeleteWalletAsync(Guid id)
        {
            var db = await _storage.LoadDatabaseAsync();
            var wallet = db.Wallets.FirstOrDefault(w => w.Id == id);
            if (wallet != null)
            {
                db.Wallets.Remove(wallet);
                db.Transactions.RemoveAll(t => t.WalletId == id);

                await _storage.SaveDatabaseAsync(db);
            }
        }

        public async Task<List<TransactionStorageModel>> GetTransactionsByWalletIdAsync(Guid walletId)
        {
            var db = await _storage.LoadDatabaseAsync();
            return db.Transactions.Where(t => t.WalletId == walletId).ToList();
        }

        public async Task<TransactionStorageModel> GetTransactionByIdAsync(Guid id)
        {
            var db = await _storage.LoadDatabaseAsync();
            return db.Transactions.FirstOrDefault(t => t.Id == id);
        }

        public async Task AddTransactionAsync(TransactionStorageModel transaction)
        {
            var db = await _storage.LoadDatabaseAsync();
            db.Transactions.Add(transaction);
            await _storage.SaveDatabaseAsync(db);
        }

        public async Task UpdateTransactionAsync(TransactionStorageModel transaction)
        {
            var db = await _storage.LoadDatabaseAsync();
            var existing = db.Transactions.FirstOrDefault(t => t.Id == transaction.Id);
            if (existing != null)
            {
                existing.Amount = transaction.Amount;
                existing.Category = transaction.Category;
                existing.Date = transaction.Date;
                existing.Description = transaction.Description;
                await _storage.SaveDatabaseAsync(db);
            }
        }

        public async Task DeleteTransactionAsync(Guid id)
        {
            var db = await _storage.LoadDatabaseAsync();
            var transaction = db.Transactions.FirstOrDefault(t => t.Id == id);
            if (transaction != null)
            {
                db.Transactions.Remove(transaction);
                await _storage.SaveDatabaseAsync(db);
            }
        }
    }
}