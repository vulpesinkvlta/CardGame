using Core.Domain;

namespace Core.Application
{
    public class SellCardResult
    {
        public bool IsSuccess { get; }
        public string Error { get; }
        public CurrencyAmount Reward { get; }

        public SellCardResult(bool isSuccess, string error, CurrencyAmount reward)
        {
            IsSuccess = isSuccess;
            Error = error;
            Reward = reward;
        }

        public static SellCardResult Success(CurrencyAmount reward)
        {
            return new SellCardResult(true, string.Empty, reward);
        }

        public static SellCardResult Failure(string error)
        {
            return new SellCardResult(false, error, null);
        }
    }
}
