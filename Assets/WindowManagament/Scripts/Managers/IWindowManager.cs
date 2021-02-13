
namespace WindowManagament.Managers
{
    public interface IWindowManager
    {
        TWindow OpenWindow<TWindowContext, TWindow>(TWindowContext context) where TWindow : IWindow<TWindowContext>, new() where TWindowContext : IWindowContext;

        TWindow OpenWindow<TWindowContext, TWindow>(TWindow window, TWindowContext context) where TWindow : IWindow<TWindowContext> where TWindowContext : IWindowContext;

        void ShowWindow<TWindow, TWindowContext>() where TWindow : IWindow<TWindowContext> where TWindowContext : IWindowContext;

        void HideWindow<TWindow, TWindowContext>() where TWindow : IWindow<TWindowContext> where TWindowContext : IWindowContext;

        void CloseWindow<TWindow, TWindowContext>() where TWindow : IWindow<TWindowContext> where TWindowContext : IWindowContext;
    }
}