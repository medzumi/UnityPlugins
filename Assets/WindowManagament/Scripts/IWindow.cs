using UnityEngine;

namespace WindowManagament
{
    public interface IWindow<TWindowContext> where TWindowContext: IWindowContext
    {
        Transform Parent { set; }

        TWindowContext Context { set; }

        void ShowWindow();

        void HideWindow();

        void CloseWindow();

        void Reset();
    }
}
