#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using UnityEditor;
using UnityEngine;


namespace WRA.PlayerSystems.LanguageSystem.Editor
{
    public class LanguageEditor : EditorWindow
    {
        private List<Language> langs = new List<Language>();

        private Dictionary<string, string> missingTranslations = new Dictionary<string, string>();

        private int choicedLang = 0;
        private int choicedCategory = 0;
        private Vector2 scrollView;
        
        private string newCategory = "New category";
        private string newKey = "New key";
        private string newTranslation = "New translation";
        
        [MenuItem("thief01/Tools/Language Editor")]
        private static void OpenWindow()
        {
            LanguageEditor window = (LanguageEditor)EditorWindow.GetWindow(typeof(LanguageEditor));
            window.Show();
        }

        private void OnValidate()
        {
            InitLangs();
        }

        private void OnEnable()
        {
            InitLangs();
        }
        
        private void InitLangs()
        {
            LanguageManager.LoadLanguage();
            langs = LanguageManager.Languages;
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();
            
            if (GUILayout.Button("Reload languages"))
            {
                InitLangs();
                return;
            }
            if (GUILayout.Button("Save language"))
            {
                SaveLanguages();
                return;
            }
            
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            var tempLang = EditorGUILayout.Popup(choicedLang, langs.Select(ctg => ctg.ShortLanguageName).ToArray());
            var tempCategory = EditorGUILayout.Popup(choicedCategory, langs[choicedLang].Categories.ToArray());
            GUILayout.EndHorizontal();
            
            GUILayout.BeginHorizontal();
            
            newCategory = EditorGUILayout.TextField(newCategory);
            if (GUILayout.Button("Add category"))
            {
                langs[choicedLang].Categories.Add(newCategory);
            }
            if (GUILayout.Button("Remove category"))
            {
                langs[choicedLang].Categories.RemoveAt(choicedCategory);
            }
            GUILayout.EndHorizontal();
            
            GUILayout.BeginHorizontal();
            
            newKey = EditorGUILayout.TextField(newKey);
            newTranslation = EditorGUILayout.TextField(newTranslation);
            if (GUILayout.Button("Add translation"))
            {
                langs[choicedLang].AddTranslation(newTranslation, new LanguageItem()
                {
                    Category = langs[choicedLang].Categories[choicedCategory],
                    Translation = newTranslation
                });
            }
            GUILayout.EndHorizontal();

            if (choicedLang != tempLang)
            {
                missingTranslations.Clear();
                choicedLang = tempLang;
                choicedCategory = 0;
            }
            
            if (choicedCategory != tempCategory)
            {
                choicedCategory = tempCategory;
            }

            DrawLangView();
        }

        private void DrawLangView()
        {
            scrollView = GUILayout.BeginScrollView(scrollView);

        
            EditorGUILayout.HelpBox("Translations", MessageType.Info);

            var translations = langs[choicedLang].GetTranslationsByCategory(langs[choicedLang].Categories[choicedCategory]);
            
            foreach (var translation in translations)
            {
                GUILayout.BeginHorizontal();
                var tempStr = EditorGUILayout.TextField(translation.Key, translation.Value.Translation);
                langs[choicedLang].LanguageItems[translation.Key].Translation = tempStr;
                if (GUILayout.Button("-", GUILayout.Width(20)))
                {
                    langs[choicedLang].LanguageItems.Remove(translation.Key);
                }
                GUILayout.EndHorizontal();
            }
            
        
            EditorGUILayout.HelpBox("Missing translations", MessageType.Info);
            
            GUILayout.EndScrollView();
        }
        
        
        private void SaveLanguages()
        {
            foreach (var lang in langs)
            {
                var path = LanguageManager.LANG_PATH + lang.ShortLanguageName + ".xml";
                var xml = lang.GetLanguageAsXml();
                
                StreamWriter sw = new StreamWriter(path, false);
                sw.Write(xml);
                sw.Close();
            }
        }
    }
}
#endif