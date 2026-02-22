using System;
using System.Collections.Generic;
using System.Text;
using Storage;

namespace Models
{
    
        public class TransactionModel
        {
            public Guid Id { get; set; }
            public Guid WalletId { get; set; }
            public decimal Amount { get; set; }
            public ExpenseCategory Category { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }

            public bool IsExpense => Amount < 0;
        }
    }

