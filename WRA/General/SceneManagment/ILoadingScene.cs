using UnityEngine.Events;

namespace WRA.General.SceneManagment
{
    public enum LoadingStatus
    {
        Loading,
        Ready,
        Running
    }
    public interface ILoadingScene
    {
        public UnityEvent OnSceneStartLoading { get; }
        public UnityEvent OnSceneReady { get; }
        public UnityEvent OnSceneStart { get; }
        
        public LoadingStatus Status { get; }
        bool IsReady();
        float GetProgress();
    
        void StartScene();
    }
}
