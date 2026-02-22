using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class TransactionModelStorage
    {
        public Guid id { get; }

        public Guid WalletId { get; }


        public decimal Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        public DateTime Date { get; set; }

        public TransactionModelStorage(Guid id, Guid walletId, decimal amount, ExpenseCategory category, DateTime date)
        {
            this.id = id;
            this.WalletId = walletId;
            this.Amount = amount;
            this.Category = category;
            this.Date = date;
        }
    }
}
