using UnityEngine;

namespace Core.Platform
{
    public class StubAuthService : IAuthService
    {
        public bool IsAuthorized { get; private set; }

        public string PlayerId { get; private set; } = "editor_player_id";

        public string PlayerName { get; private set; }  = "Editor Player";
        public void Authorize()
        {
            IsAuthorized = true;
            Debug.Log("[StubAuthService] Authorized as Editor Player is now authorized.");
        }
    }
}
