namespace Core.Domain
{
    public class PlayerProfile
    {
        public string PlayerId { get; }
        public string PlayerName { get; private set; }

        public int Rating { get; private set; }
        public int MatchesPlayed { get; private set; }
        public int MatchesWon { get; private set; }

        public PlayerProfile(
            string playerId,
            string playerName,
            int rating)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            Rating = rating;
            MatchesPlayed = 0;
            MatchesWon = 0;
        }

        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                return;

            PlayerName = newName;
        }

        public void AddRating(int amount)
        {
            if (amount <= 0)
                return;

            Rating += amount;
        }

        public void RemoveRating(int amount)
        {
            if (amount <= 0)
                return;

            Rating -= amount;

            if (Rating < 0)
                Rating = 0;
        }

        public void RegisterMatch(bool isWin)
        {
            MatchesPlayed++;

            if (isWin)
                MatchesWon++;
        }
    }
}
