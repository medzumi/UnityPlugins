using System.Collections.Generic;
using UnityEngine;
using System;

namespace WindowManagament.Managers
{
    public class WindowManager: IWindowManager
    {
        private readonly Transform root;

        private readonly Dictionary<Type, object> windowDictionary = new Dictionary<Type, object>();

        public WindowManager(Transform root)
        {
            this.root = root;
        }

        public void CloseWindow<TWindow, TWindowContext>()
            where TWindow : IWindow<TWindowContext>
            where TWindowContext : IWindowContext
        {
            ((TWindow)windowDictionary[typeof(TWindow)]).CloseWindow();
        }

        public void HideWindow<TWindow, TWindowContext>()
            where TWindow : IWindow<TWindowContext>
            where TWindowContext : IWindowContext
        {
            ((TWindow)windowDictionary[typeof(TWindow)]).HideWindow();
        }

        public TWindow OpenWindow<TWindowContext, TWindow>(TWindowContext context)
            where TWindowContext : IWindowContext
            where TWindow : IWindow<TWindowContext>, new()
        {
            var window = new TWindow();
            window.Context = context;
            window.Parent = root;
            window.Reset();
            window.ShowWindow();
            windowDictionary.Add(typeof(TWindow), window);
            return window;
        }

        public TWindow OpenWindow<TWindowContext, TWindow>(TWindow window, TWindowContext context)
            where TWindowContext : IWindowContext
            where TWindow : IWindow<TWindowContext>
        {
            window.Context = context;
            window.Parent = root;
            window.Reset();
            window.ShowWindow();
            windowDictionary.Add(typeof(TWindow), window);
            return window;
        }

        public void ShowWindow<TWindow, TWindowContext>()
            where TWindow : IWindow<TWindowContext>
            where TWindowContext : IWindowContext
        {
            ((TWindow)windowDictionary[typeof(TWindow)]).ShowWindow();
        }
    }
}
