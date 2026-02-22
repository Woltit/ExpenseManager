using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class TransactionStorageModel
    {
        public Guid id { get; }

        public Guid WalletId { get; }


        public decimal Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public TransactionStorageModel(Guid id, Guid walletId, decimal amount, ExpenseCategory category,string description  , DateTime date)
        {
            this.id = id;
            this.WalletId = walletId;
            this.Amount = amount;
            this.Category = category;
            this.Date = date;
        }
    }
}
