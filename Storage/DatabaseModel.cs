namespace Storage
{
    public class DatabaseModel
    {
        public List<WalletStorageModel> Wallets { get; set; } = new List<WalletStorageModel>();
        public List<TransactionStorageModel> Transactions { get; set; } = new List<TransactionStorageModel>();
    }
}