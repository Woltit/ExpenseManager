using System;
using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IExpenseService
    {
        List<WalletModel> GetAllWallets();
        List<TransactionModel> GetWalletTransactions(Guid walletId);
    }
}