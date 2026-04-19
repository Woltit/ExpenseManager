using Models.DTOs;
using Storage;
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

        public async Task<List<WalletListDto>> GetAllWalletsAsync()
        {
            var dbWallets = await _repository.GetAllWalletsAsync();
            var dtoList = new List<WalletListDto>();

            foreach (var w in dbWallets)
            {
                var transactions = await _repository.GetTransactionsByWalletIdAsync(w.Id);
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

        public async Task<WalletDetailDto> GetWalletDetailsAsync(Guid walletId)
        {
            var dbWallet = await _repository.GetWalletByIdAsync(walletId);
            if (dbWallet == null) return null;

            var dbTransactions = await _repository.GetTransactionsByWalletIdAsync(walletId);
            var transactionDtos = dbTransactions.Select(t => new TransactionListDto
            {
                Id = t.Id,
                Amount = t.Amount,
                Category = t.Category,
                Date = t.Date
            }).ToList();

            return new WalletDetailDto
            {
                Id = dbWallet.Id,
                Name = dbWallet.Name,
                Currency = dbWallet.Currency,
                TotalAmount = dbTransactions.Sum(t => t.Amount),
                Transactions = transactionDtos
            };
        }

        public async Task<TransactionDetailDto> GetTransactionDetailsAsync(Guid transactionId)
        {
            var dbTransaction = await _repository.GetTransactionByIdAsync(transactionId);
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


        public async Task AddWalletAsync(string name, Currency currency)
        {
            var newWallet = new WalletStorageModel(Guid.NewGuid(), name, currency);
            await _repository.AddWalletAsync(newWallet);
        }

        public async Task UpdateWalletAsync(Guid id, string name, Currency currency)
        {
            var wallet = await _repository.GetWalletByIdAsync(id);
            if (wallet != null)
            {
                wallet.Name = name;
                wallet.Currency = currency;
                await _repository.UpdateWalletAsync(wallet);
            }
        }

        public async Task DeleteWalletAsync(Guid id)
        {
            await _repository.DeleteWalletAsync(id);
        }
        public async Task AddTransactionAsync(Guid walletId, decimal amount, ExpenseCategory category, string description)
        {
            var newTx = new TransactionStorageModel(Guid.NewGuid(), walletId, amount, category, description, DateTime.Now);
            await _repository.AddTransactionAsync(newTx);
        }

        public async Task UpdateTransactionAsync(Guid transactionId, decimal amount, ExpenseCategory category, string description)
        {
            var tx = await _repository.GetTransactionByIdAsync(transactionId);
            if (tx != null)
            {
                tx.Amount = amount;
                tx.Category = category;
                tx.Description = description;
                await _repository.UpdateTransactionAsync(tx);
            }
        }

        public async Task DeleteTransactionAsync(Guid transactionId)
        {
            await _repository.DeleteTransactionAsync(transactionId);
        }
    }
}