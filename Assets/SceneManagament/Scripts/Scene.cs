//#define DBG
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

namespace SceneManagament
{
    public abstract class Scene<TSceneController> where TSceneController: SceneController
    {
        public event Action<float> OnAsyncLoad
        {
            add => sceneController.OnAsyncLoading += value;
            remove => sceneController.OnAsyncLoading -= value;
        }

        public event Action OnLoadCompleted
        {
            add => sceneController.OnLoadCompleted += value;
            remove => sceneController.OnLoadCompleted -= value;
        }

        protected abstract string SceneId { get; }

        private readonly TSceneController sceneController;

        public Scene()
        {
            sceneController = (new GameObject(SceneId + "Loading")).AddComponent<TSceneController>();
            sceneController.StartLoadingScene(SceneManager.LoadSceneAsync(SceneId));
#if DBG
            Debug.Log("<color=blue>Start loading scene:</color> " + SceneId);
#endif
        }

        ~Scene()
        {
#if DBG
            Debug.Log("Was disposed");
#endif
        }
    }
}