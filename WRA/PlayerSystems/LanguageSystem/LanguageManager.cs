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
        
        public static void LoadLanguage()
        {
            Languages = new List<Language>();
            
            ApplicationProfile.Instance.Langs.ForEach(ctg =>
            {
                Languages.Add(new Language(ctg.text));
            });


            CurrentLanguage = ApplicationProfile.Instance.Language;
            if (PlayerPrefs.HasKey("Language"))
            {
                CurrentLanguage = PlayerPrefs.GetString("Language");
            }

            SetLanguage(CurrentLanguage);
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
    }
}
