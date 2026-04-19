using Storage;


namespace Storage.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        public List<WalletStorageModel> GetAllWallets()
        {
            return StorageTemplate.Wallets.ToList();
        }

        public List<TransactionStorageModel> GetTransactionsByWalletId(Guid walletId)
        {
            return StorageTemplate.Transactions
                .Where(t => t.WalletId == walletId)
                .ToList();
        }
    }
}