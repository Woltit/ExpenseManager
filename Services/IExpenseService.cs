using Models.DTOs;
using Storage; 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IExpenseService
    {
        Task<List<WalletListDto>> GetAllWalletsAsync();
        Task<WalletDetailDto> GetWalletDetailsAsync(Guid walletId);
        Task<TransactionDetailDto> GetTransactionDetailsAsync(Guid transactionId);

        Task AddWalletAsync(string name, Currency currency);
        Task UpdateWalletAsync(Guid id, string name, Currency currency);
        Task DeleteWalletAsync(Guid id);
    }
}