using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.Utility.Diagnostics.GameConsole.Commands;
using Zenject;

[CreateAssetMenu(fileName = "CommandsInstaller", menuName = "thief01/WRA-SDK/Installers/CommandsInstaller")]
public class CommandsInstallerBase : ScriptableObjectInstaller<CommandsInstallerBase>
{
    public override void InstallBindings()
    {
        Container.Bind<ICommand>().To<ConsoleCommand>();
        Container.Bind<ICommand>().To<HelpCommand>();
        Container.Bind<ICommand>().To<LanguageCommand>();
    }
}
