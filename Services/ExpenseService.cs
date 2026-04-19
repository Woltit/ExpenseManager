using Models.DTOs;
using Storage.Repositories; 


namespace Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;

        public ExpenseService(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public List<WalletListDto> GetAllWallets()
        {
            var dbWallets = _repository.GetAllWallets();
            var dtoList = new List<WalletListDto>();

            foreach (var w in dbWallets)
            {
                var transactions = _repository.GetTransactionsByWalletId(w.Id);

                dtoList.Add(new WalletListDto
                {
                    Id = w.Id,
                    Name = w.Name,
                    Currency = w.Currency,
                    TotalAmount = transactions.Sum(t => t.Amount)
                });
            }
            return dtoList;
        }

        public WalletDetailDto GetWalletDetails(Guid walletId)
        {
            var dbWallet = _repository.GetAllWallets().FirstOrDefault(w => w.Id == walletId);
            if (dbWallet == null) return null;

            var dbTransactions = _repository.GetTransactionsByWalletId(walletId);
            var transactionDtos = new List<TransactionListDto>();

            foreach (var t in dbTransactions)
            {
                transactionDtos.Add(new TransactionListDto
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    Category = t.Category,
                    Date = t.Date
                });
            }

            return new WalletDetailDto
            {
                Id = dbWallet.Id,
                Name = dbWallet.Name,
                Currency = dbWallet.Currency,
                TotalAmount = dbTransactions.Sum(t => t.Amount),
                Transactions = transactionDtos
            };
        }

        public TransactionDetailDto GetTransactionDetails(Guid transactionId)
        {
            var dbTransaction = _repository.GetTransactionById(transactionId);
            if (dbTransaction == null) return null;

            return new TransactionDetailDto
            {
                Id = dbTransaction.Id,
                Amount = dbTransaction.Amount,
                Category = dbTransaction.Category,
                Date = dbTransaction.Date,
                Description = dbTransaction.Description 
            };
        }
    }
}