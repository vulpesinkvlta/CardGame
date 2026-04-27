using UnityEngine;

namespace Core.Platform
{
    public class StubLeaderBoardService : ILeaderBoardService
    {
        public void LoadLeaderBoard(string leaderBoardId)
        {
            Debug.Log($"[StubLeaderBoardService] LoadLeaderBoard called with leaderBoardId: {leaderBoardId}");
        }

        public void SubmitScore(string leaderBoardId, int score)
        {
            Debug.Log($"[StubLeaderBoardService] SubmitScore called with leaderBoardId: {leaderBoardId}, score: {score}");
        }
    }
}
