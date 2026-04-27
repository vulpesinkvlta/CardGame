namespace Core.Platform
{
    public interface IAuthService
    {
        bool IsAuthorized { get; }
        string PlayerId { get; }
        string PlayerName { get; }
        void Authorize();
    }
}
