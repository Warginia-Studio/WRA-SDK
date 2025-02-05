using UnityEngine;
using WRA_SDK.WRA.General;
using WRA.AudioSystem;
using WRA.CharacterSystems.StatisticsSystem;
using WRA.CharacterSystems.StatisticsSystem.Data;
using WRA.General.Cursor;
using WRA.General.SceneManagment;
using WRA.PlayerSystems.LanguageSystem;
using Zenject;

namespace WRA.General
{
    public class AplicationInstaller : MonoInstaller
    {
        [SerializeField] private CursorManager cursorManager;
        [SerializeField] private LanguageManager languageManager;
        [SerializeField] private ApplicationProfile ApplicationProfile;
        [SerializeField] private StatisticsManager statisticsManager;
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private GameManagerBase gameManagerBase;
        [SerializeField] private SceneManager customSceneManager;
        
        public override void InstallBindings()
        {
            Container.Bind<CursorManager>().FromInstance(cursorManager).AsSingle();
            Container.Bind<LanguageManager>().FromInstance(languageManager).AsSingle();
            Container.Bind<ApplicationProfile>().FromInstance(ApplicationProfile).AsSingle();
            Container.Bind<StatisticsManager>().FromInstance(statisticsManager).AsSingle();
            Container.Bind<AudioManager>().FromInstance(audioManager).AsSingle();
            Container.Bind<GameManagerBase>().FromInstance(gameManagerBase).AsSingle();
            Container.Bind<SceneManager>().FromInstance(customSceneManager).AsSingle();
        }
    }
}
