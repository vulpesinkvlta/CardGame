using Core.Domain;
using System.Collections.Generic;

namespace Core.Application
{
    public class PackOpeningResult
    {
        private readonly List<CardInstance> _cards;

        public bool IsSucces { get; }
        public string Error { get; }
        public IReadOnlyList<CardInstance> Cards => _cards;

        public PackOpeningResult(bool isSucces, string error, List<CardInstance> cards)
        {
            IsSucces = isSucces;
            Error = error;
            _cards = cards ?? new List<CardInstance>(); ;
        }

        public static PackOpeningResult Success(List<CardInstance> cards)
        {
            return new PackOpeningResult(true, string.Empty, cards);
        }

        public static PackOpeningResult Failure(string error)
        {
            return new PackOpeningResult(false, error, new List<CardInstance>());
        }
    }
}
