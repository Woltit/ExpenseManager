using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    public class WalletModelStorage
    {
        public Guid id { get; }
        public string Name { get; set; }
        public Currency Currency { get; set; }

        public WalletModelStorage(Guid id, string name, Currency currency){ 
            this.id = id;
            this.Name = name;
            this.Currency = currency;

        }
    }
}
