using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagament
{
    public abstract class PlatformScene : Scene
    {
        protected abstract string IosSceneName { get; }
        protected abstract string AndroidSceneName { get; }
        protected abstract string WindowsSceneName { get; }
        protected abstract string DefaultSceneName { get; }

        protected sealed override string SceneId
        {
            get
            {
                switch (Application.platform)
                {
                    case RuntimePlatform.Android:
                        return AndroidSceneName;
                    case RuntimePlatform.IPhonePlayer:
                        return IosSceneName;
                    case RuntimePlatform.WSAPlayerX86:
                    case RuntimePlatform.WSAPlayerX64:
                    case RuntimePlatform.WindowsEditor:
                        return WindowsSceneName;
                    default:
                        return DefaultSceneName;
                }
            }
        }
    }
}
