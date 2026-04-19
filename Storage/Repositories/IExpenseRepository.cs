using Storage;



namespace Storage.Repositories
{
    public interface IExpenseRepository
    {
        List<WalletStorageModel> GetAllWallets();
        List<TransactionStorageModel> GetTransactionsByWalletId(Guid walletId);
        TransactionStorageModel GetTransactionById(Guid id);
    }
}