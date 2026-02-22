using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class WalletStorageModel
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public Currency Currency { get; set; }

        public WalletStorageModel(Guid id, string name, Currency currency){ 
            this.Id = id;
            this.Name = name;
            this.Currency = currency;

        }
    }
}
