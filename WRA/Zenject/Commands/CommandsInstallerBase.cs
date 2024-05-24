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
            new ConsoleCommand()
        };
        public override void InstallBindings()
        {
            Container.Bind<List<ICommand>>().FromInstance(Commands);
            for (int i = 0; i < Commands.Count; i++)
            {
                Container.Bind<ICommand>().FromInstance(Commands[i]).WithConcreteId(Commands[i].Name);
            }
        }
    }
}
