using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace WRA.Utility.Diagnostics.GameConsole
{
    public class CommandInputHelper : MonoBehaviour
    {
        [SerializeField] private SimpleSelectionText selectionTextPrefab;
        [SerializeField] private TMP_InputField inputField;
    
        private List<SimpleSelectionText> spawnedSelectionTexts = new List<SimpleSelectionText>();
    
        public void ShowCommands(params string[] commands)
        {
            DestroyCommands();
        
            for (int i = 0; i < commands.Length; i++)
            {
                SimpleSelectionText simpleSelectionText = Instantiate(selectionTextPrefab, transform);
                simpleSelectionText.Bind(
                    commands[i].Replace(inputField.text, "<color=yellow><b>" + inputField.text + "</b></color>"),
                    (text) => inputField.text = commands[i]);
                spawnedSelectionTexts.Add(simpleSelectionText);
            }
        }

        public void DestroyCommands()
        {
            spawnedSelectionTexts.ForEach(ctg => Destroy(ctg.gameObject));
            spawnedSelectionTexts.Clear();
        }
    }
}
