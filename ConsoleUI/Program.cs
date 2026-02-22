using Models;
using Services;

using Storage;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpenseService expenseService = new ExpenseService();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Expense Tracker!");
                Console.WriteLine("List of your wallets:\n");


                List<WalletModel> wallets = expenseService.GetAllWallets();


                for (int i = 0; i < wallets.Count; i++)
                {
                    var wallet = wallets[i];

                    Console.WriteLine($"{i + 1}. {wallet.Name} | Balance: {wallet.TotalAmount} {wallet.Currency}");
                }


                Console.WriteLine("\n =========================");
                Console.WriteLine("Select a wallet by number to view transactions, or type '0' to quit:");

                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }
                if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= wallets.Count)
                {
                   
                    WalletModel selectedWallet = wallets[selectedIndex - 1];


                    DisplayWalletTransactions(selectedWallet);
                }
                else
                {
                    Console.WriteLine("\n Wrong input. Press Enter and try again!");
                    Console.ReadLine();
                }

            }
        }
        static void DisplayWalletTransactions(WalletModel wallet)
        {
            Console.Clear();
            Console.WriteLine($"Transactions for {wallet.Name}:\n");
            if (wallet.Transactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
            }
            else
            {
                foreach (var transaction in wallet.Transactions)
                {
                    Console.WriteLine($"{transaction.Date.ToShortDateString()} | {transaction.Category} | {transaction.Description} | Amount: {transaction.Amount}");
                }
            }
            Console.WriteLine("\nPress Enter to return to the main menu...");
            Console.ReadLine();
        }
    } 
}