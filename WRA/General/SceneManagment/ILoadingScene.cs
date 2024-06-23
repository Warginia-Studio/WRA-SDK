using UnityEngine.Events;

namespace WRA.General.SceneManagment
{
    public interface ILoadingScene
    {
        public UnityEvent OnSceneStartLoading { get; }
        public UnityEvent OnSceneReady { get; }
        public UnityEvent OnSceneStart { get; }
        bool IsReady();
        float GetProgress();
    
        void StartScene();
    }
}
