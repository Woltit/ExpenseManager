using Storage;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ExpenseService
    {

        public List<WalletModel> GetAllWallets()
        {
            var storageWallets = StorageTemplate.Wallets;
            var modelWallets = new List<WalletModel>();

            foreach (var wallet in storageWallets)
            {
                var modelWallet = new WalletModel
                {
                    Id = wallet.Id,
                    Name = wallet.Name,
                    Currency = wallet.Currency,
                    Transactions = GetWalletTransactions(wallet.Id)

                };
                modelWallets.Add(modelWallet);
            }
            return modelWallets;
        }

        public List<TransactionModel> GetWalletTransactions(Guid walletId)
        {
            var storageTransactions = StorageTemplate.Transactions
                .Where(t => t.WalletId == walletId).ToList();

            var modelTransactions = new List<TransactionModel>();

            foreach (var storageTransaction in storageTransactions)
            {
                modelTransactions.Add( new TransactionModel
                {
                    Id = storageTransaction.Id,
                    WalletId = storageTransaction.WalletId,
                    Amount = storageTransaction.Amount,
                    Category = storageTransaction.Category,
                    Description = storageTransaction.Description,
                    Date = storageTransaction.Date
                });
            }
            return modelTransactions;
        }
    }
}
