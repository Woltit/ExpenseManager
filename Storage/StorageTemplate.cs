using System;
using System.Collections.Generic;
using System.Text;
using Storage;

namespace Storage
{
    public static class StorageTemplate
    {
        public static List<WalletStorageModel> Wallets { get; } = new List<WalletStorageModel>();
        public static List<TransactionStorageModel> Transactions { get; } = new List<TransactionStorageModel>();
       
        static StorageTemplate()
        {
            AddData();
        }


        public static void AddData()
        {
            Guid monoCardID = Guid.NewGuid();
            Guid privatBankCardID = Guid.NewGuid();
            Guid visaCardID = Guid.NewGuid();

            Wallets.Add(new WalletStorageModel(monoCardID, "MonoCard", Currency.UAH));
            Wallets.Add(new WalletStorageModel(privatBankCardID, "PrivatBankCard", Currency.UAH));
            Wallets.Add(new WalletStorageModel(visaCardID, "VisaCard", Currency.USD));

            Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, 50000m, ExpenseCategory.Other,"Salary", DateTime.Now.AddDays(-10)));
            Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -500.50m, ExpenseCategory.Food, "Dinner", DateTime.Now.AddDays(-9)));
            Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -1500m, ExpenseCategory.Transport, "Train tickets", DateTime.Now.AddDays(-9)));
            Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -2000m, ExpenseCategory.Entertainment, "Amusement park", DateTime.Now.AddDays(-7)));
            Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -3000m, ExpenseCategory.Utilities, "-", DateTime.Now.AddDays(-5)));
            Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -2500m, ExpenseCategory.Healthcare, "Doctor appointment", DateTime.Now.AddDays(-4)));
            Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -1000m, ExpenseCategory.Education, "Programming book", DateTime.Now.AddDays(-3)));
            Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -4000m, ExpenseCategory.Shopping, "Zara", DateTime.Now.AddDays(-2)));
            Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -3500m, ExpenseCategory.Travel, "Travel agency", DateTime.Now.AddDays(-2)));
            Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoCardID, -4500m, ExpenseCategory.Food, "Silpo", DateTime.Now.AddDays(-1)));


            Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), visaCardID, 1000m, ExpenseCategory.Other, "Salary", DateTime.Now.AddDays(-8)));
            Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), visaCardID, -20m, ExpenseCategory.Food, "Coffe and dessert", DateTime.Now.AddDays(-7)));



        }
    }
}
