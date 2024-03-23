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
        
        private static Dictionary<string, string> LoadedLang;
        public static void LoadLanguage()
        {
            
            XmlDocument doc = new XmlDocument();
            if(ApplicationProfile.Instance.Langs == null || ApplicationProfile.Instance.Langs.Count == 0)
            {
                var path = LANG_PATH + ApplicationProfile.Instance.Language + ".xml";
                doc.Load(path);
            }
            else
            {
                var str = ApplicationProfile.Instance.Langs
                    .Find(ctg => ctg.name.Contains(ApplicationProfile.Instance.Language)).text;
                doc.LoadXml(str);
            }
        
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (XmlNode n in doc.SelectNodes("/data/*"))
            {
                d.Add(n.Name, n.InnerText);
            }

            LoadedLang = d;
            LanguageChanged.Invoke();
        }
        
        public static Dictionary<string, string> GetLanguage(string lang)
        {
            var path = LANG_PATH + lang + ".xml";
        
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
        
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (XmlNode n in doc.SelectNodes("/data/*"))
            {
                d.Add(n.Name, n.InnerText);
            }

            return d;
        }

        public static List<string> GetLanguagesList()
        {
            var langs =Directory.GetFiles(LANG_PATH, "*.xml").ToList();
            for (int i = 0; i < langs.Count; i++)
            {
                langs[i] = Path.GetFileName(langs[i].Replace(".xml", "").ToUpper());
            }

            return langs;
        }

        public static string GetTranslation(string keyWord)
        {
            if(LoadedLang==null)
                LoadLanguage();
            if (string.IsNullOrEmpty(keyWord))
            {
                return ColorHelper.GetTextInColor("KEYWORD IS NULL OR EMPTY", Color.red);
            }

            string word = "";
            try
            {
                word = LoadedLang[keyWord];
            }
            catch (Exception e)
            {
                AddMissingTranslation(keyWord);
                WraDiagnostics.LogError("Not found key word: " + keyWord + " in language: " + ApplicationProfile.Instance.Language);
                word = ColorHelper.GetTextInColor(keyWord + "_NF", Color.red);
            }

            return word;
        }

        private static void AddMissingTranslation(string keyWord)
        {
#if UNITY_EDITOR || UNITY_STANDLONE_WIN
            if (!Application.isPlaying)
                return;
            LanguageMissingTranslationsLogger.AddMissingTranslations(keyWord);
            LanguageMissingTranslationsLogger.SaveMissingTranslations();
#endif
        }
    }
}
