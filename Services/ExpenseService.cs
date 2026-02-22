using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ExpenseService
    {

        public List<WalletStorageModel> GetAllWallets()
        {
            return StorageTemplate.Wallets;
        }

        public List<TransactionStorageModel> getWalletTransactions(Guid walletId)
        {
            return StorageTemplate.Transactions.Where(t => t.WalletId == walletId).ToList();
        }
    }
}
