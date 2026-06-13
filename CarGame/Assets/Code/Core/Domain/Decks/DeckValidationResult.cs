using System.Collections.Generic;

namespace Core.Domain
{
    public class DeckValidationResult
    {
        private readonly List<string> _errors;

        public bool IsValid => _errors.Count == 0;
        public IReadOnlyList<string> Errors => _errors;

        public DeckValidationResult()
        {
            _errors = new List<string>();
        }

        public void AddError(string error)
        {
            _errors.Add(error);
        }
    }
}
