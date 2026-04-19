using Storage;

namespace Models.DTOs
{
    public class TransactionDetailDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } 
        public bool IsExpense => Amount < 0;
    }
}