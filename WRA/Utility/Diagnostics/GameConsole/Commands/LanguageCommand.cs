using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WRA.PlayerSystems.LanguageSystem;
using WRA.Utility.Diagnostics.Logs;

public class LanguageCommand : ICommand
{
    public string Name => "language";
    public string Description => "Change the language of the game";
    public string Usage => "language <language>";

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            WraDiagnostics.Log("Please provide a language code", "language");
            return;
        }

        string language = args[1];
        LanguageManager.SetLanguage(language);
        WraDiagnostics.Log("Language changed to " + language, "language");
    }
}