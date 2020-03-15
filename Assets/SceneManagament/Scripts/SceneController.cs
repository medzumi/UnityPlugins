using System.Collections;
using UnityEngine;
using System;

namespace SceneManagament
{
    public class SceneController : MonoBehaviour
    {
        public event Action<float> OnAsyncLoading = delegate { };

        public event Action OnLoadCompleted = delegate { };

        public void StartLoadingScene(AsyncOperation operation)
        {
            StartCoroutine(AsyncLoading(operation));
        }

        private IEnumerator AsyncLoading(AsyncOperation operation)
        {
            while (!operation.isDone)
            {
                OnAsyncLoading(operation.progress);
                yield return null;
            }
            Destroy(gameObject);
        }
    }
}
