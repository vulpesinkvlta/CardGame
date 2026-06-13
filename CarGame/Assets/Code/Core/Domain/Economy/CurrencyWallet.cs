using System.Collections.Generic;

namespace Core.Domain
{
    public class CurrencyWallet
    {
        private readonly Dictionary<CurrencyType, int> _balances;

        public CurrencyWallet()
        {
            _balances = new Dictionary<CurrencyType, int>();
        }

        public int GetBalance(CurrencyType currencyType)
        {
            if(_balances.TryGetValue(currencyType, out int balance))
            {
                return balance;
            }
            return 0;   
        }

        public void Add(CurrencyAmount amount)
        {
            if (amount == null)
                return;

            if(amount.Amount <= 0)
                return;

            int currentBalance = GetBalance(amount.CurrencyType);
            _balances[amount.CurrencyType] = currentBalance + amount.Amount;
        }

        public bool CanSpend(CurrencyAmount amount)
        {
            if (amount == null)
                return false;
            if(amount.Amount <= 0)
                return false;
            
            return GetBalance(amount.CurrencyType) >= amount.Amount;
        }

        public bool TrySpend(CurrencyAmount amount)
        {
            if (!CanSpend(amount))
                return false;

            _balances[amount.CurrencyType] = GetBalance(amount.CurrencyType) - amount.Amount;
            return true;
        }
    }
}
