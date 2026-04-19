using Models.DTOs;

namespace Services
{
    public interface IExpenseService
    {
        // Головна сторінка (список усіх гаманців)
        List<WalletListDto> GetAllWallets();

        // Друга сторінка (деталі конкретного гаманця, включно з транзакціями)
        WalletDetailDto GetWalletDetails(Guid walletId);

        //Третя сторінка (деталі конкретної транзакції)
        TransactionDetailDto GetTransactionDetails(Guid transactionId);
    }
}