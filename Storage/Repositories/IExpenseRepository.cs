namespace Storage.Repositories
{
    public interface IExpenseRepository
    {
        // Гаманці
        Task<List<WalletStorageModel>> GetAllWalletsAsync();
        Task<WalletStorageModel> GetWalletByIdAsync(Guid id);
        Task AddWalletAsync(WalletStorageModel wallet);
        Task UpdateWalletAsync(WalletStorageModel wallet);
        Task DeleteWalletAsync(Guid id);

        // Транзакції
        Task<List<TransactionStorageModel>> GetTransactionsByWalletIdAsync(Guid walletId);
        Task<TransactionStorageModel> GetTransactionByIdAsync(Guid id);
        Task AddTransactionAsync(TransactionStorageModel transaction);
        Task UpdateTransactionAsync(TransactionStorageModel transaction);
        Task DeleteTransactionAsync(Guid id);
    }
}