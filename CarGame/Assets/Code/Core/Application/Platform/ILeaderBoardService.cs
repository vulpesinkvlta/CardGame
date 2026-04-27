namespace Core.Platform
{       
    public interface ILeaderBoardService
    {
        void SubmitScore(string leaderBoardId, int score);
        void LoadLeaderBoard(string leaderBoardId);
    }
}
