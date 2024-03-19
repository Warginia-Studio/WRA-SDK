#if UNITY_EDITOR
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;


namespace WRA.PlayerSystems.LanguageSystem.Editor
{
    public class LanguageEditor : EditorWindow
    {
        private string[] langs;
        private List<Dictionary<string, string>> allLangs = new List<Dictionary<string, string>>();

        private Dictionary<string, string> missingTranslations = new Dictionary<string, string>();

        private int choicedLang = 0;
        private Vector2 scrollView;
        [MenuItem("thief01/Systems/Language Editor")]
        private static void OpenWindow()
        {
            LanguageEditor window = (LanguageEditor)EditorWindow.GetWindow(typeof(LanguageEditor));
            window.Show();
        }

        private void OnGUI()
        {
            if (langs != null && langs.Length > 0 && allLangs != null && allLangs.Count > 0 && allLangs[choicedLang] != null)
            {
                if (GUILayout.Button("Save language"))
                {
                    SaveLanguages();
                    return;
                }
                var tempChoice = EditorGUILayout.Popup(choicedLang, langs);

                if (choicedLang != tempChoice)
                {
                    missingTranslations.Clear();
                    choicedLang = tempChoice;
                    RefreshList();
                }
            
                DrawLangView();
            }
            else
            {
                if (GUILayout.Button("GET LANGS"))
                {
                    scrollView = Vector2.zero;
                    langs = LanguageManager.GetLanguagesList();
                    var str = "";
                    for (int i = 0; i < langs.Length; i++)
                    {
                        str += langs[i] + " ";
                        allLangs.Add(LanguageManager.GetLanguage(langs[i].Replace(".xml", "")));
                    }
                    RefreshList();
                }
            }
        }

        private void DrawLangView()
        {
            scrollView = GUILayout.BeginScrollView(scrollView);
            Dictionary<string, string> tempDictionary = new Dictionary<string, string>();
        
            EditorGUILayout.HelpBox("Translations", MessageType.Info);
        
            foreach (var VARIABLE in allLangs[choicedLang])
            {
                var tempStr = EditorGUILayout.TextField(VARIABLE.Key, VARIABLE.Value);
                tempDictionary.Add(VARIABLE.Key, tempStr);
            }

            foreach (var VARIABLE in tempDictionary)
            {
                allLangs[choicedLang][VARIABLE.Key] = VARIABLE.Value;
            }
        
            tempDictionary.Clear();
        
            EditorGUILayout.HelpBox("Missing translations", MessageType.Info);
        
            foreach (var VARIABLE in missingTranslations)
            {
                var tempStr = EditorGUILayout.TextField(VARIABLE.Key, VARIABLE.Value);
                tempDictionary.Add(VARIABLE.Key, tempStr);
            }

            foreach (var VARIABLE in tempDictionary)
            {
                missingTranslations[VARIABLE.Key] = VARIABLE.Value;
            }
        
        
        
            GUILayout.EndScrollView();
        }

        private void RefreshList()
        {
            for (int i = 0; i < allLangs.Count; i++)
            {
                if(i == choicedLang)
                    continue;
                foreach (var VARIABLE in allLangs[i])
                {
                    if(missingTranslations.ContainsKey(VARIABLE.Key))
                        continue;
                    if (!allLangs[choicedLang].ContainsKey(VARIABLE.Key))
                    {
                        missingTranslations.Add(VARIABLE.Key, VARIABLE.Value);
                    }
                }
            }
        }

        private void SaveLanguages()
        {
            foreach (var VARIABLE in missingTranslations)
            {
                allLangs[choicedLang].Add(VARIABLE.Key, VARIABLE.Value);
            }
        
            XmlDocument xmlDoc = new XmlDocument();

            // Utwórz korzeń XML
            XmlElement rootElement = xmlDoc.CreateElement("data");
            xmlDoc.AppendChild(rootElement);
        
        

            // Przejdź przez elementy słownika i dodaj je do dokumentu XML
            foreach (KeyValuePair<string, string> pair in allLangs[choicedLang])
            {
                // Utwórz nowy element dla każdej pary klucz-wartość
                XmlElement element = xmlDoc.CreateElement(pair.Key);
                element.InnerText = pair.Value;

                // // Ustaw atrybuty klucza i wartości
                // element.SetAttribute("Key", pair.Key);
                // element.SetAttribute("Value", pair.Value);

                // Dodaj element do korzenia
                rootElement.AppendChild(element);
            }

            // Zapisz dokument XML do pliku
            xmlDoc.Save(LanguageManager.LANG_PATH + "temp.xml");

            langs = null;
            choicedLang = 0;
            allLangs.Clear();
            missingTranslations.Clear();
        }
    }
}
#endif