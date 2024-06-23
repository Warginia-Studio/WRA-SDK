using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WRA.General.SceneManagment;
using SceneManager = WRA.General.SceneManagment.SceneManager;

namespace WRA.Utility.Diagnostics.GameConsole.Commands
{
    public class SceneCommand : ICommand
    {
        public string Name { get; } = "scene";
        public string Description { get; } = "Load scene by name or index";
        public string Usage { get; } = "scene <sceneName> or scene <sceneIndex>";
        public List<string> Arguments { get; } = new List<string> { "" };

        private SceneManager sceneManager;
        public void Execute(params string[] args)
        {
            if (args.Length == 0 || string.IsNullOrEmpty(args[0]))
            {
                Logs.Diagnostics.Log("Please provide scene name or index");
                return;
            }

            var sceneName = args[1];

            if(sceneManager == null)
                sceneManager = GameObject.FindFirstObjectByType<SceneManager>();
            if (int.TryParse(sceneName, out var sceneIndex))
            {
                Logs.Diagnostics.Log($"Loading scene by index: {sceneIndex}");
                sceneManager.LoadScene(sceneIndex);
            }
            else
            {
                Logs.Diagnostics.Log($"Loading scene by name: {sceneName}");
                sceneManager.LoadScene(sceneName);
            }
        }
    }
}
