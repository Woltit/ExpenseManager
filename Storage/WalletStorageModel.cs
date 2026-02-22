using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class WalletStorageModel
    {
        public Guid id { get; }
        public string Name { get; set; }
        public Currency Currency { get; set; }

        public WalletStorageModel(Guid id, string name, Currency currency){ 
            this.id = id;
            this.Name = name;
            this.Currency = currency;

        }
    }
}
