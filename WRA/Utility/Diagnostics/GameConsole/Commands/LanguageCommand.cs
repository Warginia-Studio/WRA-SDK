using WRA.PlayerSystems.LanguageSystem;
using WRA.Utility.Diagnostics.Logs;

namespace WRA.Utility.Diagnostics.GameConsole.Commands
{
    public class LanguageCommand : ICommand
    {
        public string Name => "language";
        public string Description => "Change the language of the game";
        public string Usage => "language <language>";

        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Logs.Diagnostics.Log("Please provide a language code", LogType.cmd, "language");
                return;
            }

            string language = args[1];
            LanguageManager.SetLanguage(language);
        }
    }
}