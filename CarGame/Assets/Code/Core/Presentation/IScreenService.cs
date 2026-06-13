namespace Core.Presentation
{
    public interface IScreenService
    {
        void Show<TScreen>() where TScreen : IScreen;
        void Hide<TScreen>() where TScreen : IScreen;
    }
}
