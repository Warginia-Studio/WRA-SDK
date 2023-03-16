using System.Collections.Generic;
using System.Xml;
using DependentObjects.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Utility.FileManagment
{
    public class LanguageManager
    {
        public static UnityEvent LanguageChanged = new UnityEvent();
        
        private static Dictionary<string, string> LoadedLang;
        public static void LoadLang()
        {
            var path = Application.dataPath + "/Resources/Configs/Langs/" + ApplicationProfile.Instance.Language + ".xml";
        
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
        
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (XmlNode n in doc.SelectNodes("/data/*"))
            {
                d.Add(n.Name, n.InnerText);
            }

            LoadedLang = d;
        }

        public static string GetTransation(string keyWord)
        {
            if(LoadedLang==null)
                LoadLang();
            return LoadedLang[keyWord];
        }
    }
}
