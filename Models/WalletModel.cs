using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class WalletModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }

        public List<TransactionModel> Transactions { get; set; } = new List<TransactionModel>();

     
        public decimal TotalAmount => Transactions.Sum(t => t.Amount);
    }
}
