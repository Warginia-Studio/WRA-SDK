using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;
using WRA.General;
using WRA.Utility.Diagnostics;
using WRA.Utility.Diagnostics.Logs;
using WRA.Utility.Math;

namespace WRA.PlayerSystems.LanguageSystem
{
    public class LanguageManager
    {
        public static string LANG_PATH => Application.dataPath + "/Resources/Configs/Langs/";

        public static UnityEvent LanguageChanged = new UnityEvent();
        
        public static string CurrentLanguage { get; private set; }
        public static Language CurrentLanguageData { get; set; }
        public static List<Language> Languages { get; private set; }

        private static Dictionary<SystemLanguage, string> LANGS_MAPPING = new()
        {
            { SystemLanguage.Polish , "PL"}
        };
        
        public static void LoadLanguage()
        {
            Languages = new List<Language>();
            
            ApplicationProfile.Instance.Langs.ForEach(ctg =>
            {
                Languages.Add(new Language(ctg.text));
            });


            CurrentLanguage = GetLangAsString(Application.systemLanguage);
            SetLanguage(CurrentLanguage);
        }
        
        public static void SetLanguage(SystemLanguage language)
        {
            var shortLang = "EN";
            if (LANGS_MAPPING.ContainsKey(language))
            {
                shortLang = LANGS_MAPPING[language];
            }
            else
            {
                WraDiagnostics.LogError($"Not found language: {language} in mapping. Using default language: EN");
            }
            SetLanguage(shortLang);
        }
        
        public static void SetLanguage(string language)
        {
            CurrentLanguage = language;
            PlayerPrefs.SetString("Language", language);
            PlayerPrefs.Save();
            CurrentLanguageData = Languages.FirstOrDefault(x =>
                x.ShortLanguageName == CurrentLanguage || x.LanguageName == CurrentLanguage);
            LanguageChanged.Invoke();
        }
        
        public static void NextLanguage()
        {
            var index = Languages.IndexOf(CurrentLanguageData);
            index++;
            if (index >= Languages.Count)
            {
                index = 0;
            }
            CurrentLanguageData = Languages[index];
            SetLanguage(CurrentLanguageData.ShortLanguageName);
        }
        
        public static void PreviousLanguage()
        {
            var index = Languages.IndexOf(CurrentLanguageData);
            index--;
            if (index < 0)
            {
                index = Languages.Count - 1;
            }
            CurrentLanguageData = Languages[index];
            SetLanguage(CurrentLanguageData.ShortLanguageName);
        }
        
        public static string GetTranslation(string keyWord)
        {
            if(Languages==null || Languages.Count==0)
                LoadLanguage();
            if (string.IsNullOrEmpty(keyWord))
            {
                return ColorHelper.GetTextInColor("KEYWORD IS NULL OR EMPTY", Color.red);
            }
            
            var translation = CurrentLanguageData.GetTranslation(keyWord);
            if (string.IsNullOrEmpty(translation))
            {
                WraDiagnostics.LogError("Not found key word: " + keyWord + " in language: " + ApplicationProfile.Instance.Language);
                return ColorHelper.GetTextInColor(keyWord + "_NF", Color.red);
            }

            return translation;
        }

        private static string GetLangAsString(SystemLanguage lang = SystemLanguage.Unknown)
        {
            var shortLang = "EN";
            if (LANGS_MAPPING.ContainsKey(lang))
            {
                shortLang = LANGS_MAPPING[lang];
            }
            shortLang = PlayerPrefs.GetString("Language", shortLang);
            return shortLang;
        }
    }
}
