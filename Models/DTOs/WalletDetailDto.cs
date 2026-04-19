using Storage;


namespace Models.DTOs
{
    public class WalletDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public decimal TotalAmount { get; set; }

        public List<TransactionListDto> Transactions { get; set; } = new List<TransactionListDto>();
    }
}