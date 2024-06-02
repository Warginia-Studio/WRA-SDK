using System;
using System.Collections.Generic;
using UnityEngine;
using WRA.PlayerSystems.LanguageSystem;
using LogType = WRA.Utility.Diagnostics.Logs.LogType;

namespace WRA.Utility.Diagnostics.GameConsole.Commands
{
    public class LanguageCommand : ICommand
    {
        public string Name => "language";
        public string Description => "Change the language of the game";
        public string Usage => "language <language>";
        public List<string> Arguments { get; } = new List<string>()
        {
            "language - Language name",
            "list - List of available languages"
        };

        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Logs.Diagnostics.Log("Please provide a language code", LogType.cmd, "language");
                return;
            }
            
            if (args.Length == 1)
            {
                var langList = Enum.GetNames(typeof(SystemLanguage));
                Logs.Diagnostics.Log($"Please provide a language code: {string.Join(", ", langList)}", LogType.cmd, "language");
                return;
            }
            
            if (args[1].ToLower() == "list")
            {
                var langList = Enum.GetNames(typeof(SystemLanguage));
                Logs.Diagnostics.Log($"Available languages: {string.Join(", ", langList)}", LogType.log, "language");
                return;
            }

            string language = args[1];
            try
            {
                LanguageManager.SetLanguage(SystemLanguage.TryParse(language, false, out SystemLanguage lang) ? lang : SystemLanguage.English);
            }
            catch (Exception e)
            {
                var langList = Enum.GetNames(typeof(SystemLanguage));
                Logs.Diagnostics.Log($"Language not found. Available languages: {string.Join(", ", langList)}", LogType.failed, "language");
            }
        }
    }
}