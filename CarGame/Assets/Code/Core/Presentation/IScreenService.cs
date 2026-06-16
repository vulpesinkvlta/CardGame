namespace Core.Presentation
{
    public interface IScreenService
    {
        void Register(IScreen screen);

        void Show<TScreen>() where TScreen : IScreen;
        void Hide<TScreen>() where TScreen : IScreen;

        void HideAll();
        void ShowOnly<TScreen>() where TScreen : IScreen;
    }
}
