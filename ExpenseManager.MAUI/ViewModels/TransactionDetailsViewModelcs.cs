using Models.DTOs;

namespace MAUI.ViewModels
{
    public class TransactionDetailsViewModel : BaseViewModel
    {
        public TransactionDetailDto Transaction { get; set; }

        public TransactionDetailsViewModel(TransactionDetailDto transaction)
        {
            Transaction = transaction;
        }
    }
}