using Core.Domain;

namespace Core.Application
{
    public class SellCardUseCaseResult
    {
        public bool IsSuccess { get; }
        public string Error { get; }
        public CurrencyAmount Reward { get; }
        public int RemovedFromDecksCount { get; }

        private SellCardUseCaseResult(
            bool isSuccess,
            string error,
            CurrencyAmount reward,
            int removedFromDecksCount)
        {
            IsSuccess = isSuccess;
            Error = error;
            Reward = reward;
            RemovedFromDecksCount = removedFromDecksCount;
        }

        public static SellCardUseCaseResult Success(
            CurrencyAmount reward,
            int removedFromDecksCount)
        {
            return new SellCardUseCaseResult(
                true,
                string.Empty,
                reward,
                removedFromDecksCount);
        }

        public static SellCardUseCaseResult Failure(string error)
        {
            return new SellCardUseCaseResult(
                false,
                error,
                null,
                0);
        }
    }
}
