using Core.Domain;

namespace Core.Application
{
    public class DeckOperationResult
    {
        public bool IsSuccess { get; }
        public string Error { get; }
        public Deck Deck { get; }

        private DeckOperationResult(
            bool isSuccess,
            string error,
            Deck deck)
        {
            IsSuccess = isSuccess;
            Error = error;
            Deck = deck;
        }

        public static DeckOperationResult Success(Deck deck)
        {
            return new DeckOperationResult(
                true,
                string.Empty,
                deck);
        }

        public static DeckOperationResult Failure(string error)
        {
            return new DeckOperationResult(
                false,
                error,
                null);
        }
    }
}
