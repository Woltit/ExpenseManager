using Storage;

namespace Models.DTOs
{
    public class WalletListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public decimal TotalAmount { get; set; }
    }
}