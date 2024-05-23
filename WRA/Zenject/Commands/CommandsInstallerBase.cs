using UnityEngine;
using WRA.UI.PanelsSystem;
using WRA.Utility.Diagnostics.GameConsole.Commands;
using Zenject;

namespace WRA.Zenject.Commands
{
    [CreateAssetMenu(fileName = "CommandsInstaller", menuName = "thief01/WRA-SDK/Installers/CommandsInstaller")]
    public class CommandsInstallerBase : ScriptableObjectInstaller<CommandsInstallerBase>
    {
        [Inject] PanelManager panelManager;
        
        public override void InstallBindings()
        {
            Container.Bind<ConsoleCommand>().FromInstance(new ConsoleCommand(panelManager));
            Container.Bind<HelpCommand>().FromInstance(new HelpCommand());
            Container.Bind<LanguageCommand>().FromInstance(new LanguageCommand());
        }
    }
}
