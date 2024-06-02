namespace WRA.General.SceneManagment
{
    public interface ILoadingStatus
    {
        bool IsReady();
        float GetProgress();
    
        void StartScene();
    }
}
