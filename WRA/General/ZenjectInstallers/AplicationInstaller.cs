using UnityEngine;
using UnityEngine.Serialization;
using WRA_SDK.WRA.General;
using WRA_SDK.WRA.General.ZenjectInstallers;
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
        [SerializeField] private SceneManager sceneManager;
        [SerializeField] private ManagersHolder managersHolder;
        
        public override void InstallBindings()
        {
            Container.Bind<CursorManager>().FromInstance(cursorManager).AsSingle();
            Container.Bind<LanguageManager>().FromInstance(languageManager).AsSingle();
            Container.Bind<ApplicationProfile>().FromInstance(ApplicationProfile).AsSingle();
            Container.Bind<StatisticsManager>().FromInstance(statisticsManager).AsSingle();
            Container.Bind<AudioManager>().FromInstance(audioManager).AsSingle();
            Container.Bind<SceneManager>().FromInstance(sceneManager).AsSingle();
            Container.Bind<ManagersHolder>().FromInstance(managersHolder).AsSingle();
        }
    }
}
