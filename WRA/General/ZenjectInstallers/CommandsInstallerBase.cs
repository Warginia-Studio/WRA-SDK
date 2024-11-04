using System.Collections.Generic;
using UnityEngine;
using WRA.UI.PanelsSystem;
using WRA.Utility.Diagnostics.GameConsole.Commands;
using Zenject;

namespace WRA.Zenject.Commands
{
    [CreateAssetMenu(fileName = "CommandsInstaller", menuName = "thief01/WRA-SDK/Installers/CommandsInstaller")]
    public class CommandsInstallerBase : ScriptableObjectInstaller<CommandsInstallerBase>
    {
        public List<ICommand> Commands = new List<ICommand>()
        {
            new HelpCommand(),
            new LanguageCommand(),
            new ConsoleCommand(),
            new PanelCommand(),
            new SceneCommand()
        };
        public override void InstallBindings()
        {
            Container.Bind<List<ICommand>>().FromInstance(Commands).MoveIntoAllSubContainers();
            for (int i = 0; i < Commands.Count; i++)
            {
                Container.Bind<ICommand>().WithId(Commands[i].Name).FromInstance(Commands[i]);
            }

            Container.Bind<List<ICommand>>().FromInstance(Commands);
        }
    }
}
